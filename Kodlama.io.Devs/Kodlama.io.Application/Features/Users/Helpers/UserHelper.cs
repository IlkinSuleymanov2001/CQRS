using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.Helpers
{
    public  class UserHelper
    {
        public static User SetUserPasswordDatas(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return user;
        }

        public static void SetUserStatusWhenCreated(User user, bool status=false)
          => user.Status = status;

        public static void DefaultAuthenticatorType(User user)
            => user.AuthenticatorType = AuthenticatorType.None;

    }
}
