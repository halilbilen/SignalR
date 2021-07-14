using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Model.Abstract;

namespace Model.Concrete
{
    public class ChatHub : Hub
    {

        public async Task Connected(string channelId, string clientId, string who, bool isHost)
        {
            await Clients.All.SendAsync("Connected", channelId, who, Context.ConnectionId);
        }

        public async Task JoinRoom(string channelId, string who)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, channelId);
            await Clients.Group(channelId).SendAsync("joined", channelId, Context.ConnectionId, who);
            await Clients.Group(channelId).SendAsync("ready", channelId);
        }

        public async Task ReadyRoom(string channelId)
        {
            await Clients.Group(channelId).SendAsync("ready", channelId, Context.ConnectionId);
        }

        public async Task LeaveRoom(string channelId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, channelId);
            await Clients.Group(channelId).SendAsync("bye");
        }

        public async Task SendMessage(string channelId, object message)
        {
            await Clients.OthersInGroup(channelId).SendAsync("message", message);
        }

        public async Task ToggleVideo(string channelId)
        {
            await Clients.OthersInGroup(channelId).SendAsync("toggleVideo", channelId, Context.ConnectionId);
        }

        public async Task ToggleAudio(string channelId)
        {
            await Clients.OthersInGroup(channelId).SendAsync("toggleAudio", channelId, Context.ConnectionId);
        }
    }
}
