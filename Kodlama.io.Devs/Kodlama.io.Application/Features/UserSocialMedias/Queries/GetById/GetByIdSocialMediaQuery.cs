using AutoMapper;
using Kodlama.io.Application.Features.UserSocialMedias.Dtos;
using Kodlama.io.Application.Features.UserSocialMedias.EntityBaseDependency;
using Kodlama.io.Application.Features.UserSocialMedias.Rules;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.UserSocialMedias.Queries.GetById
{
    public  class GetByIdSocialMediaQuery:IRequest<GetByIdSocialMediaDto>
    {
        public int Id { get; set; }

        public class GetByIdSocialMediaQueryHandler : UserSocialMediaDependResolver,
            IRequestHandler<GetByIdSocialMediaQuery, GetByIdSocialMediaDto>
        {
            public GetByIdSocialMediaQueryHandler(IUserSocialMediaRepository socialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules socialMediaBusinessRules) : base(socialMediaRepository, mapper, socialMediaBusinessRules)
            {
            }

            public async Task<GetByIdSocialMediaDto> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
            {
               UserSocialMedia? socialMedia = await  UserSocialMediaRepository.GetAsync(c => c.Id == request.Id);
                //null check in  busniess Role
                return Mapper.Map<GetByIdSocialMediaDto>(socialMedia);
            }
        }
    }
}
