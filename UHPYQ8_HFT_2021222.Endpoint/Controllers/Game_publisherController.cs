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
    public class Game_publisherController : ControllerBase
    {
        IGame_publisherLogic logic;

        public Game_publisherController(IGame_publisherLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Game_publisher> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Game_publisher Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Game_publisher value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Game_publisher value)
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
