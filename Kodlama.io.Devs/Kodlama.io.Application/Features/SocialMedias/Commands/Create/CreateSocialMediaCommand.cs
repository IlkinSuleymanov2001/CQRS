using AutoMapper;
using Kodlama.io.Application.Features.SocialMedias.Dtos;
using Kodlama.io.Application.Features.SocialMedias.EntityBaseDependency;
using Kodlama.io.Application.Features.SocialMedias.Rules;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using MediatR;

namespace Kodlama.io.Application.Features.SocialMedias.Commands.Create
{
    public class CreateSocialMediaCommand:IRequest<CreatedSocialMediaDto>
    {
        public string SocialMediaName { get; set; }

        public class CreateSocialMediaCommandHandler :
             SocialMediaDependResolver,
            IRequestHandler<CreateSocialMediaCommand, CreatedSocialMediaDto>
        {
            public CreateSocialMediaCommandHandler(IMapper mappper,
                ISocialMediaRepository socialMediaRepository, 
                SocialMediaBusinessRules socialMediaBusinessRules) 
                : base(mappper, socialMediaRepository, socialMediaBusinessRules)
            {}

            public async Task<CreatedSocialMediaDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                await SocialMediaBusinessRules.SocialMediaNameCanNotBeDuplicatedWhenRequested(request.SocialMediaName);
                SocialMedia mappedSocialMedia = Mapper.Map<SocialMedia>(request);
                SocialMedia addedSocialMedia = await SocialMediaRepository.AddAsync(mappedSocialMedia);
                CreatedSocialMediaDto responseDto = Mapper.Map<CreatedSocialMediaDto>(addedSocialMedia);

                return responseDto;
            }
        }
    }
}
