using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Model.Abstract;

namespace Model.Concrete
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            var date = DateTime.Now;
            await Clients.All.SendAsync("ReceiveMessage", user, message,date);
        }
    }
}
