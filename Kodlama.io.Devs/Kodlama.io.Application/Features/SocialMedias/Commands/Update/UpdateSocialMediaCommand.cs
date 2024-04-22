using AutoMapper;
using Kodlama.io.Application.Features.SocialMedias.Commands.Delete.Name;
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

namespace Kodlama.io.Application.Features.SocialMedias.Commands.Update
{
    public class UpdateSocialMediaCommand:IRequest<UpdatedSocialMediaDto>
    {
         public int Id { get; set; }
         public string SocialMediaName { get; set; }

        public class UpdateSocialMediaCommandHandler : SocialMediaDependResolver,
            IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaDto>
        {
            public UpdateSocialMediaCommandHandler(IMapper mappper,
                ISocialMediaRepository socialMediaRepository,
                SocialMediaBusinessRules socialMediaBusinessRules)
                : base(mappper, socialMediaRepository, socialMediaBusinessRules)
            {
            }

            public async Task<UpdatedSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia socialMedia = await SocialMediaBusinessRules.SocialMediaExsitsWhenRequested(request.Id);
                await SocialMediaBusinessRules.SocialMediaNameCanNotBeDuplicatedWhenRequested(request.SocialMediaName, request.Id);
                socialMedia.SocialMediaName = request.SocialMediaName;

                var updatedSocialMedia = await SocialMediaRepository.UpdateAsync(socialMedia);

                var responseDto = Mapper.Map<UpdatedSocialMediaDto>(updatedSocialMedia);
                return responseDto;

            }
        }
    }
}
