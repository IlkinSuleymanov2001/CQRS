using AutoMapper;
using Kodlama.io.Application.Features.UserSocialMedias.Rules;
using Kodlama.io.Application.Services.Repositories;

namespace Kodlama.io.Application.Features.UserSocialMedias.EntityBaseDependency
{
    public  class UserSocialMediaDependResolver
    {
        protected IUserSocialMediaRepository UserSocialMediaRepository { get; }
        protected IMapper Mapper { get; }
        protected UserSocialMediaBusinessRules UserSocialMediaBusinessRules { get; }

        public UserSocialMediaDependResolver(IUserSocialMediaRepository socialMediaRepository, IMapper mapper, UserSocialMediaBusinessRules socialMediaBusinessRules)
        {
            UserSocialMediaRepository = socialMediaRepository;
            Mapper = mapper;
            UserSocialMediaBusinessRules = socialMediaBusinessRules;
        }

    }
}
