using AutoMapper;
using Kodlama.io.Application.Features.SocialMedias.Rules;
using Kodlama.io.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.SocialMedias.EntityBaseDependency
{
    public  class SocialMediaDependResolver
    {


        public IMapper Mapper { get; }
        public ISocialMediaRepository SocialMediaRepository { get; }
        public SocialMediaBusinessRules SocialMediaBusinessRules { get; }
        public SocialMediaDependResolver(IMapper mappper,
            ISocialMediaRepository socialMediaRepository,
            SocialMediaBusinessRules socialMediaBusinessRules)
        {
            Mapper = mappper;
            SocialMediaRepository = socialMediaRepository;
            SocialMediaBusinessRules = socialMediaBusinessRules;
        }


    }
}
