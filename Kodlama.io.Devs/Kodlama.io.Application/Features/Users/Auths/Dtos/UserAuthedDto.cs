using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.Auths.Dtos
{
    public class UserAuthedDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
