using CarPoolingAPI.DTO;
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

    public async Task<UserProfileDto> GetUserById(int userId)
    {
        User rawData = await _userRepository.GetById(userId);
        
        return new UserProfileDto
        {
            Id = rawData.Id,
            FirstName = rawData.Name
        };
    }

    public async Task<UserProfileDto> AddUser(User user)
    {
        if(await UserAlreadyExists(user))
            throw new AlreadyExistsServiceException($"User with name {user.Name} already exists.");
        
        if(string.IsNullOrEmpty(user.Name))
            throw new BadRequestServiceException("Name cannot be null.");
        
        User rawData = await _userRepository.Add(user);
        return new UserProfileDto()
        {
            Id = rawData.Id,
            FirstName = rawData.Name
        };
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
            await _userRepository.GetFirstByPredicate(u => u.Name == user.Name);//TODO: Change to email
            return true;
        }
        catch (RepoDataNotFoundException)
        {
            return false;
        }
    }
}