using System.Text.Json;
using System.Web;
using HttpClients.ClientInterfaces;
using SharedDomain.DTOs;
using SharedDomain.Models;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    
    public async Task<IEnumerable<Post>> GetAsync(PostFilterDTO? filters = null)
    {
        string uri = "/post";

        // process filters
        if (filters is not null)
        {
            // this will hold the search params
            var searchParams = new List<string>();

            if (filters.Title != null)
            {
                string title = HttpUtility.UrlEncode(filters.Title);
                searchParams.Add("title=" + title);
            }
            
            if (filters.Username != null)
            {
                string username = HttpUtility.UrlEncode(filters.Username);
                searchParams.Add("username=" + username);
            }

            if (searchParams.Any())
            {
                uri += "?" + string.Join("&", searchParams);
            }
        }
        
            
        
        
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        var post = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return post;
    }
}