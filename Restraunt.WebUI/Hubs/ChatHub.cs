using Microsoft.AspNetCore.SignalR;

namespace Restraunt.WebUI.Hubs
{
    public class ChatHub:Hub
    {
       

        public async Task SendMessage(string message, Guid UserId)
        {
            
            
           await Clients.User(UserId.ToString()).SendAsync("ReceiveMessage", message);
          
        }


        public Task SendMessageToUser(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        } 
        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(ex);
        }

    }
}
