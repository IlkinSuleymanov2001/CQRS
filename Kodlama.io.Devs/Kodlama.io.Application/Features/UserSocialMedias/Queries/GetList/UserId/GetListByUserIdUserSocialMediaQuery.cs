using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Features.UserSocialMedias.EntityBaseDependency;
using Kodlama.io.Application.Features.UserSocialMedias.Models;
using Kodlama.io.Application.Features.UserSocialMedias.Rules;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.UserSocialMedias.Queries.GetList.UserId
{
    public  class GetListByUserIdUserSocialMediaQuery:IRequest<UserSocialMediaListModel>
    {

        public int UserId { get; set; }


        public class GetListByUserIdUserSocialMediaQueryHandler :
            UserSocialMediaDependResolver,
            IRequestHandler<GetListByUserIdUserSocialMediaQuery, UserSocialMediaListModel>

        {
            private readonly UserBusinessRules _userBusinessRules;
            public GetListByUserIdUserSocialMediaQueryHandler(
                IUserSocialMediaRepository socialMediaRepository,
                IMapper mapper,
                UserSocialMediaBusinessRules socialMediaBusinessRules,
                UserBusinessRules userBusinessRules) 
                : base(socialMediaRepository, mapper, socialMediaBusinessRules)
            {
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UserSocialMediaListModel> Handle(GetListByUserIdUserSocialMediaQuery request, CancellationToken cancellationToken)
            {
                User user = await _userBusinessRules.UserExistsWhenRequested(request.UserId);
                IPaginate<UserSocialMedia> userSocialMedias = await UserSocialMediaRepository.
                    GetListAsync(u => u.UserId == request.UserId,
                    include:ef=>ef.Include(c=>c.SocialMedia),
                    index:0,size:30);

                UserSocialMediaListModel userSocialMediaListModel = Mapper.Map<UserSocialMediaListModel>(userSocialMedias);
                foreach (var item in userSocialMediaListModel.Items)
                    item.Email = user.Email;


                return userSocialMediaListModel;

            }
        }

    }
}
