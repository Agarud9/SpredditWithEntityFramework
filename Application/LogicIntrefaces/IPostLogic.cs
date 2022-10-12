﻿using SharedDomain.DTOs;
using SharedDomain.Models;

namespace Application.LogicIntrefaces;

public interface IPostLogic
{
    public Task<Post> CreateAsync(PostCreationDTO dto);
    public Task<IEnumerable<Post>> GetAllAsync();
}