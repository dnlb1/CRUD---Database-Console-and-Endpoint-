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
    public class PlatformController : ControllerBase
    {
        IPlatformLogic logic;
        IHubContext<SignalRHub> hub;

        public PlatformController(IPlatformLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Platform> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Platform Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Platform value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("PlatformCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Platform value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("PlatformUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var platformDeleting = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("PlatformDeleted", platformDeleting);
        }
    }
}
