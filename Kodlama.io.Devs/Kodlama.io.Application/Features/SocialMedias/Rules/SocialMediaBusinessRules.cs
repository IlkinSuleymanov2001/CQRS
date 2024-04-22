using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Application.Services.Repositories;
using Kodlama.io.Domain.Entities;
using System.Linq.Expressions;

namespace Kodlama.io.Application.Features.SocialMedias.Rules
{
    public class SocialMediaBusinessRules
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaBusinessRules(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }


        public async Task<SocialMedia> SocialMediaExsitsWhenRequested(object IdOrName)
        {
            Expression<Func<SocialMedia, bool>> expression = (IdOrName is int) ? c => c.Id == (int)IdOrName : c => c.SocialMediaName==(string)IdOrName;
            SocialMedia?  response = await _socialMediaRepository.GetAsync(expression);
            if (response == null) throw new BusinessException("Social Media does not exists..");
            return response;
        }

        public async Task SocialMediaNameCanNotBeDuplicatedWhenRequested(string name,int? id=null) 
        {
            Expression<Func<SocialMedia, bool>> expression =
                (id==null) ? c => c.SocialMediaName==name
                : c => c.Id != id && c.SocialMediaName == name;
            SocialMedia?  socialMedia = await _socialMediaRepository.GetAsync(expression);
            if (socialMedia != null) throw new BusinessException("Name Already exists..");
        }

    }
}
