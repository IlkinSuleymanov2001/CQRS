using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.Authentications.Rules
{
    public  class AuthBusinessRoles
    {

        public void PasswordVerifyWhenLogin(User user, string outPassword) 
        {
            var isLogin = HashingHelper.VerifyPasswordHash(outPassword,
                user.PasswordHash, user.PasswordSalt);
            if (!isLogin) { throw new AuthorizationException("Password doesnt Correct.."); }
        }
    }
}
