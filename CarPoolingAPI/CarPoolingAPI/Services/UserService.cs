using CarPoolingAPI.Exceptions;
using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using CarPoolingAPICore.Repository;

namespace CarPoolingAPI.Services;

public class UserService : IUserService
{
    private IRepository<int, User> _userRepository;

    public class FakeRepo : BaseRepository<int, User>
    {
        public FakeRepo() : base()
        {
            Entities.Add(new User { Id = 1, Name = "John" });
            Entities.Add(new User { Id = 2, Name = "Jane" });
        }
    }

    public UserService(IRepository<int, User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IList<User>> SearchUsers(int maxCount)
    {
        return await _userRepository.GetAll(maxCount);
    }

    public async Task<User> GetUserById(int userId)
    {
        return await _userRepository.GetById(userId);
    }

    public async Task<User> AddUser(User user)
    {
        throw new NotImplementedException();
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
}