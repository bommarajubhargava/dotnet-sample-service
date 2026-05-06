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

        public string GetUserEmail(int userId)
        {
            var user = _repo.FindById(userId);
            if (user == null)
                throw new InvalidOperationException($"User with id {userId} was not found.");
            return user.Email;
        }

        public void DeactivateUser(int userId)
        {
            var user = _repo.FindById(userId);
            if (user == null)
                throw new InvalidOperationException($"User with id {userId} was not found.");
            user.IsActive = false;
            _repo.Save(user);
        }
    }
}
