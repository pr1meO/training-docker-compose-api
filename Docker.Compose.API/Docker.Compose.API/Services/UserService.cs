using Docker.Compose.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Docker.Compose.API.Services
{
    public interface IUserService
    {
        Task<User> AddAsync(string firstname, string login);
        Task<IEnumerable<User>> GetAsync();
        Task<User?> GetByIdAsync(Guid id);
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<User> AddAsync(string firstname, string login)
        {
            var user = new User()
            {
                Firstname = firstname,
                Login = login
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
