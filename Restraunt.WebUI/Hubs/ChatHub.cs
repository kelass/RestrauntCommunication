using IdentityModel.Client;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Restraunt.Core.Dto;
using System.Net.Http;
using System.Text;

namespace Restraunt.WebUI.Hubs
{
    public class ChatHub:Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChatHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendMessage(OrderDto order)
        {
            
            
           

            var apiClient = _httpClientFactory.CreateClient();

            var json = JsonConvert.SerializeObject(order);
            var postData = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiClient.PostAsync("https://localhost:7167/api/Order", postData);

            

            var content = await response.Content.ReadAsStringAsync();

            await Clients.User(order.UserId.ToString()).SendAsync("ReceiveMessage", order);

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
