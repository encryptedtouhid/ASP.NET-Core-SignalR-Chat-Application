using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatSample.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("broadcastMessage", name, message);
        }

        public async Task SendMessage(Message message)
        {
            message.Timestamp = DateTime.Now;
            await Clients.Users(message.Sender.ToString(), message.Recipient.ToString()).SendAsync("broadcastMessage", message.RecipientUniqueCode, message.Contents );
        }
    }
}