using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MessageClient.Models;

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
    public IActionResult Index(AppUser user)
    {
      AppUser.Post(user);
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }
  }
}