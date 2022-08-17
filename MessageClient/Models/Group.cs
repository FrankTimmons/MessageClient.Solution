using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MessageClient.Models
{
  public class Group
  {
    public int GroupId { get; set; }
    public string GroupName { get; set; } = default!;
    public static List<Group> GetGroups()
    {

      var apiCallTask = ApiHelper.GetAll("groups");
      var result = apiCallTask.Result;
      
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Group> groupList = JsonConvert.DeserializeObject<List<Group>>(jsonResponse.ToString());

      return groupList;
    }

    public static Group GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get("groups", id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Group group = JsonConvert.DeserializeObject<Group>(jsonResponse.ToString());

      return group;
    }

    public static void Post(Group group)
    {
      string jsonGroup = JsonConvert.SerializeObject(group);
      var apiCallTask = ApiHelper.Post("groups", jsonGroup);
    }

     public static void Put(Group group)
    {
      string jsonGroup = JsonConvert.SerializeObject(group);
      var apiCallTask = ApiHelper.Put("groups", group.GroupId, jsonGroup);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete("groups", id);
    }
  }
}