using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
  }
}