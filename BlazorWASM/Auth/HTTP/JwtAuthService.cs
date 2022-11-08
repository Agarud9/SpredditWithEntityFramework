using System.Security.Claims;
using System.Text;
using System.Text.Json;
using SharedDomain.DTOs;
using SharedDomain.Models;

namespace BlazorWASM.Auth.HTTP;

public class JwtAuthService : IAuthService
{
    private readonly HttpClient client = new();
    public static string? Jwt { get; private set; } = "";
    
    public async Task LoginAsync(string username, string password)
    {
        LoginDTO user = new LoginDTO(username, password);

        // User --> as json
        string userAsJson = JsonSerializer.Serialize(user);
        // Putting the json into a string content
        StringContent content = new StringContent(userAsJson, Encoding.UTF8, "application/json");
        
        // Making a post request
        HttpResponseMessage response = await client.PostAsync("https://localhost:7031/User/login", content);
        // Reading the response content which is should be a JWT
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine(responseContent);
            throw new Exception(responseContent);
        }
        
        string token = responseContent;
        Jwt = token;
        
        
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        OnAuthStateChanged?.Invoke(principal);
    }
    
    private static ClaimsPrincipal CreateClaimsPrincipal()
    {
        if (string.IsNullOrEmpty(Jwt))
        {
            return new ClaimsPrincipal();
        }

        IEnumerable<Claim> claims = ParseClaimsFromJwt(Jwt);
    
        ClaimsIdentity identity = new(claims, "jwt");

        ClaimsPrincipal principal = new(identity);
        return principal;
    }

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }


    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }

    public Task RegisterAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }

    // Method that will fire an event whenever the authentication state changes
    // upon a log in or log out
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}