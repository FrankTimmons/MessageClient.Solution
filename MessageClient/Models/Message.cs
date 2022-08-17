using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageClient.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public int GroupId { get; set; }
    public string Body { get; set; } = default!;
    public string Author { get; set; } = default!;
    public DateTime DatePosted { get; set; }

    public static List<Message> GetMessages()
    {
      var apiCallTask = ApiHelper.GetAll("messages");
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Message> messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

      return messageList;
    }

    public static Message GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get("messages", id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Message message = JsonConvert.DeserializeObject<Message>(jsonResponse.ToString());

      return message;
    }

    public static void Post(Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      var apiCallTask = ApiHelper.Post("messages", jsonMessage);
    }

    public static void Put(Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      var apiCallTask = ApiHelper.Put("messages", message.MessageId, jsonMessage);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete("messages", id);
    }
  }
}