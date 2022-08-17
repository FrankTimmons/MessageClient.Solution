using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MessageClient.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

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
      ViewBag.CurrentTime = DateTime.Now;
      var allGroups = Group.GetGroups();
      ViewBag.GroupId = new SelectList( allGroups, "GroupId", "GroupName");
      var allMessages = Message.GetMessages();
      return View(allMessages);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }

    [HttpPost]
    public IActionResult Index(Message message)
    {     
      Message.Post(message);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
		{
			var message = Message.GetDetails(id);
      ViewBag.Group = Group.GetDetails(message.GroupId);
			return View(message);
		}

		[HttpPost]
		public IActionResult Details(int id, Message message)
		{
			message.MessageId = id;
			Message.Put(message);
			return RedirectToAction("Details", id);
		}

		public IActionResult Edit(int id)
    {
      var allGroups = Group.GetGroups();
      ViewBag.GroupId = new SelectList( allGroups, "GroupId", "GroupName");
      var message = Message.GetDetails(id);
      return View(message);
    }

		public IActionResult Delete(int id)
    {
      Message.Delete(id);
      return RedirectToAction("Index");
    }
  }
}