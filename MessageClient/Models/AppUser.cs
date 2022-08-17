using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageClient.Models
{
  public class AppUser
  {
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;

    public static void Post(AppUser user)
    {
      string jsonUser = JsonConvert.SerializeObject(user);
      var apiCallTask = AuthorizationHelper.Register(jsonUser);
    }
  }
}