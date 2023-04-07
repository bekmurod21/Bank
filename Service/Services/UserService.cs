using AutoMapper;
using Service.Interface;
using System.Linq.Expressions;
using Data.IRepositories;
using Service.DTOs;
using Domain.Entities;

namespace Service.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserForResultDto> AddUserAsync(UserForCreationDto dto)
        {
            var user = await userRepository.SelectAsync(user => user.FirstName.ToLower() == dto.FirstName.ToLower());
            if (user != null)
                throw new Exception("Already exists!");
            var mappeduser = mapper.Map<User>(dto);
            mappeduser.CreatedAt = DateTime.UtcNow;
            var addeduser = await userRepository.InsertAsync(mappeduser);
            return mapper.Map<UserForResultDto>(addeduser);

        }

        public async Task<bool> DeleteUserAsync(Expression<Func<User, bool>> predicate)
        {
            var user = await userRepository.SelectAsync(predicate);
            if (user == null)
                throw new Exception("NOT FOUND!");
            await userRepository.DeleteAsync(predicate);
            return true;
        }

        public async Task<IEnumerable<UserForResultDto>> GetAllUserAsync(Expression<Func<User, bool>> predicate = null)
        {
            var users = userRepository.SelectAllAsync();
            users = predicate != null ? users.Where(predicate) : users;
            var mappedUsers = mapper.Map<IEnumerable<UserForResultDto>>(users);
            return mappedUsers;
        }

        public async Task<UserForResultDto> GetUserAsync(Expression<Func<User, bool>> predicate)
        {
            var user = await userRepository.SelectAsync(predicate);
            var mappedUser = mapper.Map<UserForResultDto>(user);
            return mappedUser;
        }

        public async Task<UserForResultDto> UpdateUserAsync(long id, UserForCreationDto dto)
        {
            var user = await userRepository.SelectAsync(p => p.Id == id);
            if (user == null)
                throw new Exception("NOT FOUND!");

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.BirthOfDate = dto.BirthOfDate;
            user.Password = dto.Password;
            user.UpdatedAt = DateTime.UtcNow;

            await userRepository.UpdateAsync(user);

            return mapper.Map<UserForResultDto>(user);

        }

    }
}
