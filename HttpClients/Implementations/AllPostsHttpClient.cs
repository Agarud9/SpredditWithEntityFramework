using System.Text.Json;
using HttpClients.ClientInterfaces;
using SharedDomain.Models;

namespace HttpClients.Implementations;

public class AllPostsHttpClient : IAllPostsService
{
    private readonly HttpClient httpClient;

    public AllPostsHttpClient(HttpClient client)
    {
        httpClient = client;
    }
    
    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        string uri = "/post";
        HttpResponseMessage response = await httpClient.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<IEnumerable<Post>> GetPostsByUserAsync(String? username)
    {
        string query = $"/post/?username={username}";
        HttpResponseMessage response = await httpClient.GetAsync(query);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }
}