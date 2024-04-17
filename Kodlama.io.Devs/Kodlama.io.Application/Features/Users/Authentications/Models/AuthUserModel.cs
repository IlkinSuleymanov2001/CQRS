using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.Auths.Models
{
    public class AuthUserModel
    {
        public AccessToken AccessToken { get; set; }
        public string  Message  { get; set; }
    }
}
