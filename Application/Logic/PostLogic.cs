using Application.DaoInterfaces;
using Application.LogicIntrefaces;
using SharedDomain.DTOs;
using SharedDomain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private IPostDao postDao;
    private IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }


    public async Task<Post> CreateAsync(PostCreationDTO dto)
    {
        //Searching if the user exists 
        User? user = await userDao.GetByUsernameAsync(dto.Username);
        if (user == null)
        {
            throw new Exception($"User with username: {dto.Username} not found.");
        }
        
        //A new post is created
        Post post = new Post(dto.Title, dto.Body, user);
        
        //Validating the new post
        ValidatePost(post);
        
        //Handing over to the DAO, which return the finalized object
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAllAsync()
    {
        return postDao.GetAllAsync();
    }

    public async Task<IEnumerable<Post>?> GetByTitleAsync(string title)
    {
        return await postDao.GetByTitleAsync(title);
    }
    
    private static void ValidatePost(Post post)
    {
        if (string.IsNullOrEmpty(post.title))
        {
            throw new Exception("The title can not be empty");
        }

        if (string.IsNullOrEmpty(post.body))
        {
            throw new Exception("The body of the post can not be empty");
        }
    }
}