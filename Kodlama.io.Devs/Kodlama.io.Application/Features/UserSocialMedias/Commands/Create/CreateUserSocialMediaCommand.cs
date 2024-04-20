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

namespace Kodlama.io.Application.Features.UserSocialMedias.Commands.Create
{
    public  class CreateUserSocialMediaCommand :IRequest<CreatedUserSocialMediaDto>
    {
        public int UserId { get; set; }
        public int  SocialMediaId { get; set; }
        public string SocialMediaLink { get; set; }

        public class CreateUserSocialMediaCommandHandler :UserSocialMediaDependResolver,  IRequestHandler<CreateUserSocialMediaCommand, CreatedUserSocialMediaDto>
        {
            public CreateUserSocialMediaCommandHandler(IUserSocialMediaRepository socialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules socialMediaBusinessRules) : base(socialMediaRepository, mapper, socialMediaBusinessRules)
            {
            }

            public async  Task<CreatedUserSocialMediaDto> Handle(CreateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                // Busines role yazarsan [name and  link] uniques olsun 
                // business role useri tapsin eks halde xeta atsin 
                // validator elave et.
                UserSocialMedia userSocialMedia =  Mapper.Map<UserSocialMedia>(request);
                var addedUserSocialMedia  = await UserSocialMediaRepository.AddAsync(userSocialMedia);

                var fullDataForUserSocialMedia =await UserSocialMediaRepository.GetAsync(predicate: p => p.Id == addedUserSocialMedia.Id,
                    include: ef => {
                        var queryUserSocialMedia = ef
                        .Include(c => c.SocialMedia)
                        .Include(c => c.User);
                        return queryUserSocialMedia;
                            });

                return Mapper.Map<CreatedUserSocialMediaDto>(fullDataForUserSocialMedia);
            }
        }

    }
}
