using Autenticacao.Models;

namespace Autenticacao.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User AddUser(User user)
        {
            return user; // Simulating adding a user to a database
        }

        public User GetUserByEmail(string email)
        {
            return new User
            {
                Id = 1,
                Name = "John Doe",
                Email = email,
                Access = "User", // Simulating a user with access level
                Password = "123" // Simulating a user fetched from a database
            }; // Simulating fetching a user by email
        }
    }
}