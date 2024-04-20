using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.UserSocialMedias.Dtos
{
    public  class GetByIdUserSocialMediaDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaLink { get; set; }
    }
}
