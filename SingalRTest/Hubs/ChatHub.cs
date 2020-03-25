using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingalRTest.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        static int i = 0;
        public override Task OnConnectedAsync()
        {
          
            if (i/2==0)
            {
                Groups.AddToGroupAsync(Context.ConnectionId, "1");
            }
            i++;      
            return base.OnConnectedAsync();
          
        }
        public async Task SendMessageToSpe(string user, string message)
        {
            await Clients.Group("1").SendAsync("ReceiveMessage", user, message);
        }


    }
}
