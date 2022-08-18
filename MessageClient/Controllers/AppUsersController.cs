using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MessageClient.Models;
using Json.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageClient.Controllers
{
  public class AppUsersController : Controller
  {
    private readonly ILogger<AppUsersController> _logger;

    public AppUsersController(ILogger<AppUsersController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(AppUser user)
    {
      var response = await AppUser.Post(user);
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response);
      AppUser.Token = ((string)jsonResponse["token"]);      
      return View("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }
  }
}