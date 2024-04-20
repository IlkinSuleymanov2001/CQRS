using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Domain.Entities
{
    public class UserSocialMedia:Entity
    {
        public int UserId { get; set; }
        public int  SocialMediaId { get; set; }
        public string SocialMediaLink { get; set; }
        public virtual  User User { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }

        public UserSocialMedia() { }

        public UserSocialMedia(int userId, int  socialMediaId, string socialMediaLink):this()
        {
            UserId = userId;
            SocialMediaId = socialMediaId;
            SocialMediaLink = socialMediaLink;
        }
    }
}
