using MyApi.Data;
using MyApi.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Business.UserServ
{
    public class UserService
    {
        private readonly MyDbContext _context;

        public UserService(MyDbContext context)
        {
            _context = context;
        }

       

        public async Task<User?> PostUser(User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
            if (existingUser != null)
            {
                return null; 
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user ?? null; 
        }

        public async Task<User?> Login(User loginUser)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == loginUser.UserName && u.Password == loginUser.Password);
            return user ?? null; 
        }

        public async Task<User?> Forgot(User forgotUser)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == forgotUser.Email);
            return user ?? null; 
        }


        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
