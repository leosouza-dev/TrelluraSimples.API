using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrelluraSimples.API.Hubs
{
    public class TrelluraHub : Hub
    {
        public async Task CreateCard(string user, int id)
        {
            await Clients.All.SendAsync("createCard", user, id);
        }

        public async Task UpdateCard(string user, int id)
        {
            await Clients.All.SendAsync("updateCard", user, id);
        }

        public async Task DeleteCard(string user, int id)
        {
            await Clients.All.SendAsync("deleteCard", user, id);
        }

        //board
    }
}
