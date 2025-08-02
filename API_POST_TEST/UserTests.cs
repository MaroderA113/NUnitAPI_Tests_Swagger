using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API_POST_TEST;

[TestClass]
public class UserTests
{
    [TestMethod]
    public async Task User_Should_Be_Register_201_Created()
    {
        const string path = "users/register";
        
        var user = new UserRequest
        {
            Username = "tracey.ramos",
            Email = "tracey.ramos@reqres.in",
            Password = "Qwerty123"
        };

        var jsonRequest = JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented = true });
        var content = new StringContent(jsonRequest, Encoding.UTF8, @"application/json");

        var client = Service.GetClient(); 
        var response = await client.PostAsync(path, content);
        response.EnsureSuccessStatusCode(); // статус ответа 201

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Assert.IsNotEmpty(jsonResponse); // содержимое ответа не пустое
        
        var userResponse = JsonSerializer.Deserialize<UserResponse>(jsonResponse);
        Assert.IsNotNull(userResponse!.Id); // ИД пользователя существует
        Assert.AreEqual(user.Username, userResponse!.Username);
        Assert.AreEqual(user.Email, userResponse!.Email);
        Assert.AreEqual(user.Password, userResponse!.Password);
    }
}