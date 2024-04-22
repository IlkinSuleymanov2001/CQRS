using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.UserSocialMedias.Rules
{
    public class UserSocialMediaBusinessRules
    {
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;

        public UserSocialMediaBusinessRules(IUserSocialMediaRepository userSocialMediaRepository)
        {
            _userSocialMediaRepository = userSocialMediaRepository;
        }

        public async Task<UserSocialMedia> UserSocialMediaExsitsWhenRequested(int id)
        {
            Expression<Func<UserSocialMedia, bool>> expression = c => c.Id == id;
            UserSocialMedia? response = await _userSocialMediaRepository.GetAsync(predicate: expression);
            if (response == null) throw new BusinessException("User SocialMedia does not exists..");
            return response;
        }

        public async Task UserAndLinkMustBeUniqueWhenRequested(int userId , string socialMediaLink)
        {
            Expression<Func<UserSocialMedia, bool>> expression = c => c.UserId == userId && c.SocialMediaLink.Equals(socialMediaLink);
            var  socialMedia = await _userSocialMediaRepository.GetAsync(expression);
            if (socialMedia != null) throw new BusinessException("Link Already exists for User..");
        }

        public void UserSocialMediaNullCheck(UserSocialMedia userSocialMedia)
        {
            if (userSocialMedia == null) throw new BusinessException("User Social Media exists..");
        }
    }
}
