using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.UserSocialMedias.Dtos
{
    public class GetListUserSocialMediaDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaLink { get; set; }
    }
}
