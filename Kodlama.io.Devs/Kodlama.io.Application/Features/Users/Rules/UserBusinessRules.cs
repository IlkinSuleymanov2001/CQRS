using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Application.Features.Users.Rules
{
    public  class UserBusinessRules
    {
        private IUserRepository _userRepository;
        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> UserExistsWhenRequested(int id)
        {
            User? isExistsUser = await _userRepository.GetAsync(u => u.Id == id);
            if (isExistsUser == null) { throw new BusinessException("User does not exsits.."); }
            return isExistsUser;
        }

        public async Task<User> UserExistsWhenRequested(string email)
        {
            User? isExistsUser = await _userRepository.GetAsync(u => u.Email == email);
            if (isExistsUser == null) { throw new BusinessException("User does not exsits.."); }
            return isExistsUser;
        }

        public async Task UserEmailCanNotBeDublicatedWhenCreated(string email)
        {
               var users = await _userRepository.GetListAsync(u => u.Email == email);
            if (users.Items.Any())
            {
                throw new BusinessException("Email using already other account");
            }
        }

        public async  Task UserEmailCanNotBeDublicatedWhenUpdated(int id, string email)
        {
            User? isExistsUser = await _userRepository.GetAsync(u =>u.Id!=id  && u.Email == email);
            if (isExistsUser!=null) { throw new BusinessException("User Email Exists.."); }
        }
    }
}
