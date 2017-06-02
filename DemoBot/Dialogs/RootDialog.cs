using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DemoBot.Dialogs {
	[Serializable]
	public class RootDialog : IDialog<object> {
		public Task StartAsync(IDialogContext context) {
			context.Wait(MessageReceivedAsync);

			return Task.CompletedTask;
		}

		private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result) {
			var activity = await result as Activity;

			if (activity.Text.ToLower().Contains("weather")) {
				await context.PostAsync("Weather is good today. =)");
			} else if (activity.Text.ToLower().Contains("name")) {
				await context.PostAsync("My name is Igor");
			} else if (activity.Text.ToLower().Contains("joke") || activity.Text.ToLower().Contains("yes")) {
				await context.PostAsync("What is the difference between a snowman and a snowwoman? \n\n\n\nSnowballs.");
			} else {
				await context.PostAsync("Bla-bla-bla. I don't understand you. Do you want a joke?");
			}

			context.Wait(MessageReceivedAsync);
		}
	}
}