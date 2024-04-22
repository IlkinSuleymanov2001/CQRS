using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Application.Features.SocialMedias.Dtos;
using Kodlama.io.Application.Features.SocialMedias.EntityBaseDependency;
using Kodlama.io.Application.Features.SocialMedias.Models;
using Kodlama.io.Application.Features.SocialMedias.Queries.GetList;
using Kodlama.io.Application.Features.SocialMedias.Rules;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.SocialMedias.Queries.GetById
{
    public class GetByIdSocialMediaQuery:IRequest<GetByIdSocialMediaDto>
    {
        public int Id { get; set; }
        public class GetByIdSocialMediaQueryHandler :
          SocialMediaDependResolver,
          IRequestHandler<GetByIdSocialMediaQuery, GetByIdSocialMediaDto>
        {
            public GetByIdSocialMediaQueryHandler(IMapper mappper,
            ISocialMediaRepository socialMediaRepository,
            SocialMediaBusinessRules socialMediaBusinessRules)
            : base(mappper, socialMediaRepository, socialMediaBusinessRules)
            {
            }

            public async Task<GetByIdSocialMediaDto> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
            {
                SocialMedia socialMedia = await SocialMediaBusinessRules.SocialMediaExsitsWhenRequested(request.Id);
                var responseDto = Mapper.Map<GetByIdSocialMediaDto>(socialMedia);

                return responseDto;
            
            }
        }

    }
}
