using AutoMapper;
using Kodlama.io.Application.Features.UserSocialMedias.Dtos;
using Kodlama.io.Application.Features.UserSocialMedias.EntityBaseDependency;
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

namespace Kodlama.io.Application.Features.UserSocialMedias.Queries.GetById
{
    public  class GetByIdSocialMediaQuery:IRequest<GetByIdUserSocialMediaDto>
    {
        public int Id { get; set; }

        public class GetByIdSocialMediaQueryHandler : UserSocialMediaDependResolver,
            IRequestHandler<GetByIdSocialMediaQuery, GetByIdUserSocialMediaDto>
        {
            public GetByIdSocialMediaQueryHandler(IUserSocialMediaRepository socialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules socialMediaBusinessRules) : base(socialMediaRepository, mapper, socialMediaBusinessRules)
            {
            }

            public async Task<GetByIdUserSocialMediaDto> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
            {
                UserSocialMedia? socialMedia = await  UserSocialMediaRepository.
                    GetAsync(c => c.Id == request.Id,
                             include:ef=>ef.Include(c=>c.SocialMedia));

                UserSocialMediaBusinessRules.UserSocialMediaNullCheck(socialMedia);

                return Mapper.Map<GetByIdUserSocialMediaDto>(socialMedia);
            }
        }
    }
}
