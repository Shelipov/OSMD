using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Web;

namespace OSMD.Models
{
    
    public class ChatHub : Hub<dynamic>
    {
        public async Task SendMessage(string message, string userName)
        {
           // string timestamp = DateTime.Now.ToShortTimeString();
            await Clients.All.InvokeAsync("ReceiveMessage", message, userName);
            
        }
    }
}
