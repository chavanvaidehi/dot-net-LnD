using Microsoft.EntityFrameworkCore;
using RefactoredLoginApp.Data;
using RefactoredLoginApp.Models;
using System.Threading.Tasks;

namespace RefactoredLoginApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
