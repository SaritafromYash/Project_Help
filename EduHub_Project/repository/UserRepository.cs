using EduHub_Project.Models;
using EduHub_Project.services;
using Microsoft.EntityFrameworkCore;

namespace EduHub_Project.repository
{
    public class UserRepository : IUserService
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<User> GetUserAsync(long userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAllStudentsAsync()
        {
            var students = await _context.Users.Where(u => u.UserRole == "Student").ToListAsync();
            return  students;
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateUserAsync(long userId, User updatedUser)
        {
            var existingUser = await _context.Users.FindAsync(userId);
            if (existingUser == null)
                return null;

            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;
            existingUser.UserName = updatedUser.UserName;
            existingUser.MobileNumber = updatedUser.MobileNumber;
            existingUser.UserRole = updatedUser.UserRole;
            existingUser.ProfileImage = updatedUser.ProfileImage;

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(long userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}