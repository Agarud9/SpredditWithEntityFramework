﻿using Application.DaoInterfaces;
using SharedDomain.DTOs;
using SharedDomain.Models;

namespace FileData.DAOs;

public class PostDaoImpl : IPostDao
{
    private readonly FileContext context;

    public PostDaoImpl(FileContext context)
    {
        this.context = context;
    }
    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;
        
        if (context.Posts.Any())
        {
            //Looking through all post id s and finding the biggest one
            postId = context.Posts.Max(t => t.id);
            postId++;
        }

        post.id = postId;

        context.Posts.Add(post);
        context.SaveChange();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAllAsync()
    {
        IEnumerable<Post> result = context.Posts.AsEnumerable();

        return Task.FromResult(result);
    }

    public Task<IEnumerable<Post>?> GetByTitleAsync(string title)
    {
        IEnumerable<Post> posts = context.Posts.Where(p => p.title.Equals(title,StringComparison.OrdinalIgnoreCase));
        if (!posts.Any())
        {
            throw new Exception($"Post with title: {title} doesn't exist");
        }

        return Task.FromResult(posts);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? post = context.Posts.FirstOrDefault(p => p.id == id);
        return Task.FromResult(post);
    }
}