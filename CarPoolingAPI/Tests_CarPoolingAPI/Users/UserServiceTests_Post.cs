﻿using System.Net;
using CarPoolingAPI.DTO;
using CarPoolingAPI.Exceptions;
using CarPoolingAPICore.Exceptions;
using CarPoolingAPICore.Models;
using Moq;

namespace Tests_CarPoolingAPI;

[TestFixture(Category = "Post")]
public class UserServiceTests_Post : UserServiceTests
{
    private UserRegisterRequestDto _userRegisterRequestDto;
    
    public override void Setup()
    {
        base.Setup();

        _userRegisterRequestDto = UserRegisterRequestDto.MapFromUser(TestData.ValidUser);
    }

    [Test]
    public void AddUser_NoThrow()
    {
        SetupUserMockingDoesntExist();
        _mockUserRepo.Setup(repo => repo.Add(It.IsAny<User>())).ReturnsAsync(TestData.ValidUser);

        Assert.DoesNotThrowAsync(() => _service.AddUser(TestData.ValidUser));
    }

    [Test]
    public async Task AddUser_AddSucceed()
    {
        SetupUserMockingDoesntExist();
        _mockUserRepo.Setup(repo => repo.Add(It.IsAny<User>())).ReturnsAsync(TestData.ValidUser);
        _mockUserRepo.CallBase = false;

        await _service.AddUser(TestData.ValidUser);

        _mockUserRepo.Verify(repo => repo.Add(It.IsAny<User>()), Times.Once);
        Assert.Pass();
    }

    [Test]
    public void AddUser_ThrowWhenAlreadyExists()
    {
        _mockUserRepo.Setup(repo => repo.GetFirstByPredicate(It.IsAny<Func<User, bool>>())).ReturnsAsync(TestData.ValidUser);//Find it in data

        Assert.ThrowsAsync<AlreadyExistsServiceException>(async () => await _service.AddUser(TestData.ValidUser));
    }

    [Test]
    public void AddUser_ThrowWhenUserEmpty()
    {
        SetupUserMockingDoesntExist();

        Assert.ThrowsAsync<BadRequestServiceException>(() => _service.AddUser(new User()));
    }

    private void SetupUserMockingDoesntExist()
    {
        _mockUserRepo.Setup(repo => repo.GetFirstByPredicate(It.IsAny<Func<User, bool>>())).Throws(new RepoDataNotFoundException());
    }
}