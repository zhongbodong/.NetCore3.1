﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebPack.Hubs
{
  
        public class ChatHub : Hub
        {
            public async Task NewMessage(long username, string message)
            {
                await Clients.All.SendAsync("messageReceived", username, message);
            }
        }

}
