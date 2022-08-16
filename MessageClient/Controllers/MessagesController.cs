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
  public class MessagesController : Controller
  {
    private readonly ILogger<MessagesController> _logger;

    public MessagesController(ILogger<MessagesController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      var allMessages = Message.GetMessages();
      return View(allMessages);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }
  }
}