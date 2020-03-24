using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class ChatHub: Hub
    {
        public async Task SendMessageAsync(Message message) => await Clients.All.SendAsync("receivingMessage", message);
    }
}
