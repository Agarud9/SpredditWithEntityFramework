﻿using Application.DaoInterfaces;
using Application.LogicIntrefaces;
using SharedDomain.DTOs;
using SharedDomain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private IUserDao dao;
    
    public UserLogic(IUserDao dao)
    {
        this.dao = dao;
    }
    
    public async Task<UserToSendDTO> CreateUser(User user)
    {
        User? existing = await dao.GetByUsernameAsync(user.Username);

        if (existing != null)
        {
            throw new Exception($" Username: {user.Username} already exists");
        }
        
        ValidateData(user);
         
        return await dao.CreateUser(user);
    }

    private static void ValidateData(User user)
    {
        string username = user.Username;

        if (username.Length > 20 || username.Length < 5)
        {
            throw new Exception("Username must have more than 5 characters and less than 21");
        }

        DateTime dateOfBirth = user.DateOfBirth;
        int age = (int)((DateTime.Now - dateOfBirth).TotalDays / 365.242199);
        
        if (age < 14)
        {
            throw new Exception("Age is less than 14");
        }
    }
}