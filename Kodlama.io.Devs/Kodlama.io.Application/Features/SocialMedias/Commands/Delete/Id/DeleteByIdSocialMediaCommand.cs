using AutoMapper;
using Kodlama.io.Application.Features.SocialMedias.Dtos;
using Kodlama.io.Application.Features.SocialMedias.EntityBaseDependency;
using Kodlama.io.Application.Features.SocialMedias.Rules;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.SocialMedias.Commands.Delete.Id
{
    public  class DeleteByIdSocialMediaCommand:IRequest<DeletedSocialMediaDto>
    {

        public int Id { get; set; }

        public class DeleteByIdSocailMediaCommandHandler : SocialMediaDependResolver,
            IRequestHandler<DeleteByIdSocialMediaCommand, DeletedSocialMediaDto>
        {
            public DeleteByIdSocailMediaCommandHandler(IMapper mappper,
                ISocialMediaRepository socialMediaRepository, 
                SocialMediaBusinessRules socialMediaBusinessRules)
                : base(mappper, socialMediaRepository, socialMediaBusinessRules)
            {
            }

            public async Task<DeletedSocialMediaDto> Handle(DeleteByIdSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia socialMedia = await SocialMediaBusinessRules.SocialMediaExsitsWhenRequested(request.Id);
                var deletedresponse = await SocialMediaRepository.DeleteAsync(socialMedia);
                DeletedSocialMediaDto response  = Mapper.Map<DeletedSocialMediaDto>(deletedresponse);

                return response;
                       
            }
        }
    }
}
