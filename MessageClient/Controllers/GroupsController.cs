using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MessageClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageClient.Controllers
{
  public class GroupsController : Controller
  {
    private readonly ILogger<GroupsController> _logger;

    public GroupsController(ILogger<GroupsController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      var allGroups = Group.GetGroups();
      return View(allGroups);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View("Error!");
    }


		[HttpPost]
    public IActionResult Index(Group group)
    {
			Group.Post(group);
			return RedirectToAction("Index");
    }

		public IActionResult Details(int id)
		{
			var group = Group.GetDetails(id);
			return View(group);
		}

		[HttpPost]
		public IActionResult Details(int id, Group group)
		{
			group.GroupId = id;
			Group.Put(group);
			return RedirectToAction("Details", id);
		}

		public IActionResult Edit(int id)
    {
      var group = Group.GetDetails(id);
      return View(group);
    }

    [HttpPost]
    public IActionResult Edit(Group group)
    {     
      Group.Put(group);
      return RedirectToAction("Index");
    }

		public IActionResult Delete(int id)
    {
      Group.Delete(id);
      return RedirectToAction("Index");
    }
  }
}