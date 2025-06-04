using Autenticacao.Models;

namespace Autenticacao.Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserByEmail(string email);
    }
}