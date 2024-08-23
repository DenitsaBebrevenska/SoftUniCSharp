using Microsoft.AspNetCore.Mvc;
using SimpleChatApp.Models.Message;

namespace SimpleChatApp.Controllers;
public class ChatController : Controller
{
	//just for the task, that is a bad practice
	private static readonly IList<KeyValuePair<string, string>> Messages =
		new List<KeyValuePair<string, string>>();

	[HttpGet]
	public IActionResult Show()
	{
		if (!Messages.Any())
		{
			return View(new ChatViewModel());
		}

		var chatModel = new ChatViewModel()
		{
			Messages = Messages
				.Select(m => new MessageViewModel()
				{
					Sender = m.Key,
					Text = m.Value
				})
				.ToList()
		};

		return View(chatModel);
	}

	[HttpPost]
	public IActionResult Send(ChatViewModel chatModel)
	{
		var newMessage = chatModel.CurrentMessage;
		Messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.Text));

		return RedirectToAction("Show");
	}
}
