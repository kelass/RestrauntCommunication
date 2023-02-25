using Microsoft.AspNetCore.SignalR;

namespace Restraunt.WebUI.Hubs
{
    public class ChatHub:Hub
    {
        public async Task JoinToGroup(Guid TableId)
        {
            

            await Groups.AddToGroupAsync(Context.ConnectionId, "Table");

            await SendMessage();
        }

        public async Task SendMessage()
        {
            string message = "1";

            await Groups.AddToGroupAsync("ReceiveMessage:", message);
            
        }
    }
}
