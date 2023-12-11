using ApplicationCore.Enumeration;
using FAIS.ApplicationCore.DTOs;
using FAIS.ApplicationCore.Entities.Security;
using FAIS.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FAIS.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<User> Get()
        {
            return _repository.Get();
        }

        public User GetById(decimal id)
        {
            return _repository.GetById(id);
        }

        public User GetByUserName(string userName)
        {
            return _repository.GetByUserName(userName);
        }

        public async Task<User> LockedAccount(UserDTO userDto)
        {
            var user = _repository.GetById(userDto.Id);

            user.StatusCode = (int)LoginEnum.UserStatus.Locked;

            return await _repository.LockedAccount(user);
        }

        public async Task<User> UpdateSignInAttempts(UserDTO userDto)
        {
            var user = _repository.GetById(userDto.Id);

            user.SignInAttempts = userDto.LoginStatus == (int)LoginEnum.LoginStatus.Success ? 0 : (user.SignInAttempts + 1);

            return await _repository.UpdateSignInAttempts(user);
        }
    }
}
