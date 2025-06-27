using RefactoredLoginApp.Models;
using System.Threading.Tasks;

namespace RefactoredLoginApp.Repositories
{
    public interface IUserRepository
    {
        Task<User> ValidateUserAsync(string username, string password);
    }
}
