using Domain.Entities;
using Service.DTOs;
using System.Linq.Expressions;

namespace Service.Interface
{
    public interface IUserService
    {
        Task<UserForResultDto> AddUserAsync(UserForCreationDto dto);
        Task<UserForResultDto> UpdateUserAsync(long id, UserForCreationDto dto);
        Task<bool> DeleteUserAsync(Expression<Func<User, bool>> predicate);
        Task<UserForResultDto> GetUserAsync(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<UserForResultDto>> GetAllUserAsync(Expression<Func<User, bool>> predicate = null);
        
    }
}
