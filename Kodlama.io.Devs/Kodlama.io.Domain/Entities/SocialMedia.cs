using Core.Persistence.Repositories;



namespace Kodlama.io.Domain.Entities
{
    public  class SocialMedia:Entity
    {
        public string  SocialMediaName { get; set; }

        public SocialMedia()
        {
        }

        public SocialMedia(int id,string socialMediaName):this()
        {
            Id = id;
            SocialMediaName = socialMediaName;
        }
    }
}
