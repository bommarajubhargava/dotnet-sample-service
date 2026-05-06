using System;

namespace DotnetSampleService.Services
{
    public class UserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        // BUG: no null check — throws NullReferenceException when user not found
        public string GetUserEmail(int userId)
        {
            var user = _repo.FindById(userId);
            return user.Email;
        }

        public void DeactivateUser(int userId)
        {
            var user = _repo.FindById(userId);
            user.IsActive = false;
            _repo.Save(user);
        }
    }
}
