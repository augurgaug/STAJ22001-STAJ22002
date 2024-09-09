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
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.user_name == user.user_name);
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
                .FirstOrDefaultAsync(u => u.user_name == loginUser.user_name && u.password == loginUser.password);
            return user ?? null;
        }

        public async Task<User?> Forgot(User forgotUser)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.email == forgotUser.email);
            return user ?? null;
        }


        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> GetUsersCount()
        {
            return await _context.Users.CountAsync();
        }

     



        public async Task<bool> UpdateUserr(int id, User updatedUserr)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }


            user.push_token = updatedUserr.push_token;


            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}