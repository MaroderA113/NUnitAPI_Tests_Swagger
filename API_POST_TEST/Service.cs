using System;
using System.Net.Http;

namespace API_POST_TEST;

public static class Service
{
    private const string Url = "https://reqres.in/api/";
    private const string ApiKey = "reqres-free-v1";

    private static readonly HttpClient HttpClient;

    static Service()
    {
        HttpClient = new HttpClient();
        HttpClient.BaseAddress = new Uri(Url);
        HttpClient.DefaultRequestHeaders.Add("x-api-key", ApiKey);
    }
    
    public static HttpClient GetClient() => HttpClient;
}

public class UserRequest
{
    public string Username {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
}

public class UserResponse
{
    public string Username {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public int Id {get; set;}
}
