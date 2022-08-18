using System.Threading.Tasks;
using RestSharp;

namespace MessageClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll(string requestType)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{requestType}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(string requestType, int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{requestType}/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string requestType, string newPost)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{requestType}", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + AppUser.Token);
      request.AddJsonBody(newPost);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(string requestType, int id, string newPut)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{requestType}/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + AppUser.Token);
      request.AddJsonBody(newPut);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(string requestType, int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"{requestType}/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + AppUser.Token);
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}