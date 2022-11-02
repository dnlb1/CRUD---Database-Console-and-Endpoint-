using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UHPYQ8_HFT_2021222.Endpoint.Services;
using UHPYQ8_HFT_2021222.Logic.Classes;
using UHPYQ8_HFT_2021222.Models;

namespace UHPYQ8_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameLogic logic;
        IHubContext<SignalRHub> hub;

        public GameController(IGameLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }
        [HttpGet]
        public IEnumerable<Game> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Game Get(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Game value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("GameCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Game value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("GameUpdated", value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var gameDeleting = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("GameDeleted", gameDeleting);
        }
    }
}
