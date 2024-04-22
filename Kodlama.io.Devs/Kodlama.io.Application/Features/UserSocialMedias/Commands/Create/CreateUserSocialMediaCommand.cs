using AutoMapper;
using Kodlama.io.Application.Features.SocialMedias.Rules;
using Kodlama.io.Application.Features.Users.Rules;
using Kodlama.io.Application.Features.UserSocialMedias.Dtos;
using Kodlama.io.Application.Features.UserSocialMedias.EntityBaseDependency;
using Kodlama.io.Application.Features.UserSocialMedias.Rules;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Application.Features.UserSocialMedias.Commands.Create
{
    public  class CreateUserSocialMediaCommand :IRequest<CreatedUserSocialMediaDto>
    {
        public int UserId { get; set; }
        public int  SocialMediaId { get; set; }
        public string SocialMediaLink { get; set; }

        public class CreateUserSocialMediaCommandHandler :UserSocialMediaDependResolver,  IRequestHandler<CreateUserSocialMediaCommand, CreatedUserSocialMediaDto>
        {

            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;
            private readonly UserBusinessRules _userBusinessRules;
            public CreateUserSocialMediaCommandHandler(
                IUserSocialMediaRepository socialMediaRepository,
                IMapper mapper, 
                UserSocialMediaBusinessRules socialMediaBusinessRules,
                SocialMediaBusinessRules socialMediaBusiness,
                UserBusinessRules userBusinessRules) 
                : base(socialMediaRepository, mapper, socialMediaBusinessRules)
            {
                _socialMediaBusinessRules = socialMediaBusiness;
                _userBusinessRules = userBusinessRules;
            }

            public async  Task<CreatedUserSocialMediaDto> Handle(CreateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserExistsWhenRequested(request.UserId);
                await _socialMediaBusinessRules.SocialMediaExsitsWhenRequested(request.SocialMediaId);
                await UserSocialMediaBusinessRules.UserAndLinkMustBeUniqueWhenRequested(request.UserId,request.SocialMediaLink);

                UserSocialMedia mappedUserSocialMedia =  Mapper.Map<UserSocialMedia>(request);
                var addedUserSocialMedia  = await UserSocialMediaRepository.AddAsync(mappedUserSocialMedia);

                return Mapper.Map<CreatedUserSocialMediaDto>(addedUserSocialMedia);
            }

        }

    }
}
