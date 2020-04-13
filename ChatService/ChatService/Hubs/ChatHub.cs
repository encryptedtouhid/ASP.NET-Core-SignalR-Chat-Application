using ChatService.Entity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatSample.Hubs
{
    public class ChatHub : Hub
    {
        chatdbContext dbContext = new chatdbContext();

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

            ChatService.Entity.Message msg = new ChatService.Entity.Message();
            msg.MessageUniqueCode = Guid.NewGuid();
            msg.RecipientConnectionId = message.RecipientConnectionId;
            msg.RecipientName = message.RecipientName;
            msg.RecipientUniqueCode = message.RecipientUniqueCode;
            msg.SenderConnectionId = message.SenderConnectionId;
            msg.SenderName = message.SenderName;
            msg.SenderUniqueCode = message.SenderUniqueCode;
            msg.Timestamp = System.DateTime.Now;

            dbContext.Message.Add(msg);
            dbContext.SaveChanges();

            message.Timestamp = DateTime.Now;
            await Clients.Client(message.SenderConnectionId).SendAsync("ReceiveMessage", message.SenderName, message.Contents);
            await Clients.Client(message.RecipientConnectionId).SendAsync("ReceiveMessage", message.SenderName, message.Contents);
        }

        //public async Task SendMessage(Message message)
        //{
        //    message.Timestamp = DateTime.Now;
        //    await Clients.Users(message.Sender.ToString(), message.Recipient.ToString()).SendAsync("ReceiveMessage", message.Sender, message.Contents );
        //}
    }
}