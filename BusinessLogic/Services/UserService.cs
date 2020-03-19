using BusinessLogic.Models;
using BusinessLogic.Repositories;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task AddAsync(User user)
        {
            await userRepository.AddAsync(user);
        }

        public async Task RemoveAsync(int userId)
        {
            await userRepository.RemoveAsync(userId);
        }

        public async Task UpdateAsync(int userId, User newuser)
        {
            await userRepository.UpdateAsync(userId, newuser);
        }
    }
}
