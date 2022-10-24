using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using SharedDomain.Models;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    
    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/post");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Post> post = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return post;
    }
}