using AutoMapper;
using Kodlama.io.Application.Features.UserSocialMedias.Rules;
using Kodlama.io.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.UserSocialMedias.EntityBaseDependency
{
    public  class UserSocialMediaDependResolver
    {
        protected IUserSocialMediaRepository UserSocialMediaRepository { get; }
        protected IMapper Mapper { get; }
        protected UserSocialMediaBusinessRules SocialMediaBusinessRules { get; }

        public UserSocialMediaDependResolver(IUserSocialMediaRepository socialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules socialMediaBusinessRules)
        {
            UserSocialMediaRepository = socialMediaRepository;
            Mapper = mapper;
            SocialMediaBusinessRules = socialMediaBusinessRules;
        }

    }
}
