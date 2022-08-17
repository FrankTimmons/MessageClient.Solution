using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;


namespace MessageClient.Models
{
  public class AuthorizationHelper
  {
    public static async Task<string> Get(string requestType)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"authmanagement", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Register(string newPost)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"authmanagement/register", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Login(string newPost)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"authmanagement/login", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPost);
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}