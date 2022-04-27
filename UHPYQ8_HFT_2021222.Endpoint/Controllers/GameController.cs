using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UHPYQ8_HFT_2021222.Logic.Classes;
using UHPYQ8_HFT_2021222.Models;

namespace UHPYQ8_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameLogic logic;

        public GameController(IGameLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Game value)
        {
            this.logic.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
