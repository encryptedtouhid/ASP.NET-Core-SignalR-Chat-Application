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

        public async Task SendMessage(Guid senderID, Guid recipientID, string contents)
        {
            Message newMessage = new Message()
            {
                SenderUniqueCode = senderID,
                RecipientUniqueCode = recipientID,
                Contents = contents,
                Timestamp = DateTime.UtcNow
            };
            _dbContext.Message.Add(newMessage);
            await _dbContext.SaveChangesAsync();


            await Clients.Users(senderID.ToString(), newMessage.RecipientUniqueCode.ToString()).SendAsync("ReceiveMessage", newMessage);
        }

        //public async Task GetUserOnlineStatus(string UserID)
        //{
        //    int userID = 0;
        //    if (int.TryParse(UserID, out userID) == false)
        //        throw new InvalidCastException("UserID should be a number");

        //    DateTime lastActive = await _statusMonitorService.GetUserStatus(userID);
        //    if (lastActive == new DateTime(0))
        //        await Clients.Caller.SendAsync("ReceiveUserStatus", 0);
        //    else
        //        await Clients.Caller.SendAsync("ReceiveUserStatus", lastActive);
        //}

    }
}
