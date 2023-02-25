using Microsoft.AspNetCore.SignalR;

namespace Restraunt.WebUI.Hubs
{
    public class ChatHub:Hub
    {


        public async Task SendMessage(string table,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", table, message);
        }
    }
}
