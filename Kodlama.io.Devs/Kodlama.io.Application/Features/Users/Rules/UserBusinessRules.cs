using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.io.Application.Services.Repositories;
using System.Linq.Expressions;

namespace Kodlama.io.Application.Features.Users.Rules
{
    public  class UserBusinessRules
    {
        private IUserRepository _userRepository;
        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> UserExistsWhenRequested(object IdOrEmail)
        {
            Expression<Func<User, bool>> expression = 
                (IdOrEmail is int) ? c => c.Id == (int)IdOrEmail : c => c.Email == (string)IdOrEmail;
            User? isExistsUser = await _userRepository.GetAsync(expression);
            if (isExistsUser == null) { throw new BusinessException("User does not exsits.."); }
            return isExistsUser;
        }

     

        public async Task UserEmailCanNotBeDublicatedWhenRequested(string email,int? id=null)
        {
            Expression<Func<User, bool>> expression =
                (id == null) ? c => c.Email == email
                : c => c.Id != id && c.Email == email;

            var users = await _userRepository.GetListAsync(expression);

            if (users.Items.Any())
                throw new BusinessException("Email using already other account");
            
        }
    }
}
