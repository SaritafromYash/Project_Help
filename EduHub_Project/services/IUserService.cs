using EduHub_Project.Models;

namespace EduHub_Project.services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(long userId);
        Task<IEnumerable<User>> GetAllStudentsAsync();
        Task<User> CreateUserAsync(User newUser);
        Task<User> UpdateUserAsync(long userId, User updatedUser);
        Task<bool> DeleteUserAsync(long userId);
    }
}
