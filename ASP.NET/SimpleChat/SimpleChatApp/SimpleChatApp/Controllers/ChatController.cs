using Microsoft.AspNetCore.Mvc;

namespace SimpleChatApp.Controllers;
public class ChatController : Controller
{
    //just for the task, that is a bad practice
    private static IList<KeyValuePair<string, string>> _messages =
        new List<KeyValuePair<string, string>>();

    public IActionResult Show()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Send()
    {
        return RedirectToAction("Show");
    }
}
