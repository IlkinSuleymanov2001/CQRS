using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Application.Features.SocialMedias.EntityBaseDependency;
using Kodlama.io.Application.Features.SocialMedias.Models;
using Kodlama.io.Application.Features.SocialMedias.Rules;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.SocialMedias.Queries.GetList
{
    public  class GetListSocialMediaQuery:IRequest<SocialMediaListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSocialMediaQueryHandler :
            SocialMediaDependResolver,
            IRequestHandler<GetListSocialMediaQuery, SocialMediaListModel>
        {
            public GetListSocialMediaQueryHandler(IMapper mappper, 
                ISocialMediaRepository socialMediaRepository,
                SocialMediaBusinessRules socialMediaBusinessRules) 
                : base(mappper, socialMediaRepository, socialMediaBusinessRules)
            {
            }

            public async  Task<SocialMediaListModel> Handle(GetListSocialMediaQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialMedia> socailMediaPaginate =  await SocialMediaRepository.
                    GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                SocialMediaListModel responseModel = Mapper.Map<SocialMediaListModel>(socailMediaPaginate);
                return responseModel;

            }
        }
    }
}
