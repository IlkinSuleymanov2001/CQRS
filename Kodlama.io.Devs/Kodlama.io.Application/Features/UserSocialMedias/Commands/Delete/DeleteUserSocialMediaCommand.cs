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

namespace Kodlama.io.Application.Features.UserSocialMedias.Commands.Delete
{
    public class DeleteUserSocialMediaCommand : IRequest<DeletedUserSocialMediaDto>
    {
        public int Id { get; set; }

        public class DeleteUserSocialMediaCommandHandler :
            UserSocialMediaDependResolver,
            IRequestHandler<DeleteUserSocialMediaCommand, DeletedUserSocialMediaDto>
        {
            public DeleteUserSocialMediaCommandHandler(
                IUserSocialMediaRepository socialMediaRepository,
                IMapper mapper,
                UserSocialMediaBusinessRules socialMediaBusinessRules)
                : base(socialMediaRepository, mapper, socialMediaBusinessRules)
            { }

            public async Task<DeletedUserSocialMediaDto> Handle(DeleteUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                UserSocialMedia? userSocialMedia = await UserSocialMediaRepository.GetAsync(c => c.Id == request.Id, include: ef => ef.Include(c => c.SocialMedia));
                //null Check 
                await UserSocialMediaRepository.DeleteAsync(userSocialMedia);
                DeletedUserSocialMediaDto responseDto = Mapper.Map<DeletedUserSocialMediaDto>(userSocialMedia);

                return responseDto;
            }
        }
    }
}
