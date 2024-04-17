using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Domain.Entities
{
    public class UserSocialMedia:Entity
    {
        public int UserId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaLink { get; set; }
        public User User { get; set; }

        public UserSocialMedia() { }

        public UserSocialMedia(int userId, string socialMediaName, string socialMediaLink):this()
        {
            UserId = userId;
            SocialMediaName = socialMediaName;
            SocialMediaLink = socialMediaLink;
        }
    }
}
