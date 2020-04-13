using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatSample.Hubs
{
    public class ChatHub : Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        public async Task Send(string name, string message)
        {
            await Clients.All.SendAsync("broadcastMessage", name, message);
        }

        public async Task SendMessage(Message message)
        {
            message.Timestamp = DateTime.Now;
            await Clients.Client(message.SenderConnectionId).SendAsync("ReceiveMessage", message.Sender, message.Contents);
            await Clients.Client(message.RecipientConnectionId).SendAsync("ReceiveMessage", message.Sender, message.Contents);
        }

        //public async Task SendMessage(Message message)
        //{
        //    message.Timestamp = DateTime.Now;
        //    await Clients.Users(message.Sender.ToString(), message.Recipient.ToString()).SendAsync("ReceiveMessage", message.Sender, message.Contents );
        //}
    }
}