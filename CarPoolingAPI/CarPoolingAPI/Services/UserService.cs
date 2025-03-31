﻿using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Interface;
using CarPoolingAPICore.Models;
using CarPoolingAPICore.Repository;

namespace CarPoolingAPI.Services;

public class UserService : IUserService
{
    private IRepository<int, User> _userRepository;

    private class FakeRepo : BaseRepository<int, User>
    {
        public FakeRepo() : base()
        {
            Entities.Add(new User { Id = 1, Name = "John" });
            Entities.Add(new User { Id = 2, Name = "Jane" });
        }
    }

    public UserService()
    {
        _userRepository = new FakeRepo();
    }

    public IList<User> SearchUsers(int maxCount)
    {
        return _userRepository.GetAll(maxCount).Result;
    }

    public User GetUserById(int userId)
    {
        return _userRepository.GetById(userId).GetAwaiter().GetResult();
    }

    public User AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(int userId)
    {
        throw new NotImplementedException();
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