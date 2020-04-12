using ChatAPI.Entity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI
{
    public class ChatHub : Hub
    {
        private chatdbContext _dbContext;

        public ChatHub(chatdbContext AppDbContext)
        {
            _dbContext = AppDbContext;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(Message message)
        {
            Message newMessage = new Message()
            {
                SenderUniqueCode = message.SenderUniqueCode,
                RecipientUniqueCode = message.RecipientUniqueCode,
                Contents = message.Contents,
                Timestamp = DateTime.UtcNow
            };
            _dbContext.Message.Add(newMessage);
            await _dbContext.SaveChangesAsync();


            await Clients.Users(message.SenderUniqueCode.ToString(), newMessage.RecipientUniqueCode.ToString()).SendAsync("ReceiveMessage", newMessage);
        }


    }
}
