using System.Collections;
using CarPoolingAPI.DTO;
using CarPoolingAPI.Exceptions;
using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using CarPoolingAPICore.Repository;

namespace CarPoolingAPI.Services;

public sealed class UserService : IUserService
{
    private IRepository<int, User> _userRepository;

    public class FakeRepo : Repository<int, User>
    {
        public FakeRepo() : base(null)
        {
            // Entities.Add(new User { Id = 1, FirstName = "John", Email = "test@test.com", HashedPassword = "123"});
            // Entities.Add(new User { Id = 2, FirstName = "Jane", Email = "test@test.com", HashedPassword = "123"});
        }
    }

    public UserService(IRepository<int, User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ICollection<UserProfileResultDto>> SearchUsers(int maxCount)
    {
        IEnumerable<User> list = await _userRepository.GetAll(maxCount);

        return list.Select(UserProfileResultDto.MapFromUser).ToArray();
    }

    public async Task<UserProfileResultDto> GetUserById(int userId)
    {
        try
        {
            User rawData = await _userRepository.GetById(userId);
            return UserProfileResultDto.MapFromUser(rawData);
        }
        catch (RepoDataNotFoundException)
        {
            throw new NotFoundServiceException($"User with id {userId} not found.");
        }
    }

    public async Task<User> GetFirstByPredicate(Func<User, bool> predicate)
    {
        try
        {
            User rawData = await _userRepository.GetFirstByPredicate(predicate);
            return rawData;
        }
        catch (RepoDataNotFoundException)
        {
            throw new NotFoundServiceException($"User not found.");
        }
    }

    public async Task<User> AddUser(User user)
    {
        if (await UserAlreadyExists(user))
            throw new AlreadyExistsServiceException($"User with name {user.FirstName} already exists.");

        if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.Email))
            throw new BadRequestServiceException("Name cannot be null.");

        User rawData = await _userRepository.Add(user);
        return rawData;
    }

    public async Task DeleteUser(int userId)
    {
        try
        {
            await _userRepository.DeleteById(userId);
        }
        catch (RepoDataNotFoundException)
        {
            throw new NotFoundServiceException($"User with id {userId} not found.");
        }
    }

    public void Dispose()
    {
        _userRepository.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _userRepository.DisposeAsync();
    }

    private async Task<bool> UserAlreadyExists(User user)
    {
        try
        {
            await _userRepository.GetFirstByPredicate(u => u.Email == user.Email);
            return true;
        }
        catch (RepoDataNotFoundException)
        {
            return false;
        }
    }
}