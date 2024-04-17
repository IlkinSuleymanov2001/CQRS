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

namespace Kodlama.io.Application.Features.UserSocialMedias.Commands.Create
{
    public  class CreateUserSocialMediaCommand :IRequest<CreateUserSocialMediaDto>
    {
        public int UserId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaLink { get; set; }

        public class CreateUserSocialMediaCommandHandler :UserSocialMediaDependResolver,  IRequestHandler<CreateUserSocialMediaCommand, CreateUserSocialMediaDto>
        {
            public CreateUserSocialMediaCommandHandler(IUserSocialMediaRepository socialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules socialMediaBusinessRules) : base(socialMediaRepository, mapper, socialMediaBusinessRules)
            {
            }

            public async  Task<CreateUserSocialMediaDto> Handle(CreateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                // Busines role yazarsan [name and  link] uniques olsun 
                // business role useri tapsin eks halde xeta atsin 
                // validator elave et.
                UserSocialMedia userSocialMedia =  Mapper.Map<UserSocialMedia>(request);
                var addedUserSocialMedia  = await UserSocialMediaRepository.AddAsync(userSocialMedia);
                return Mapper.Map<CreateUserSocialMediaDto>(addedUserSocialMedia);
            }
        }

    }
}
