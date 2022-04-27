using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UHPYQ8_HFT_2021222.Logic.Classes;
using UHPYQ8_HFT_2021222.Models;



namespace UHPYQ8_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IGameLogic gameLogic;

        public StatController(IGameLogic gameLogic)
        {
            this.gameLogic = gameLogic;
        }

        [HttpGet]
        public double GameAVGPrice()
        {
            return gameLogic.GameAVGPrice();
        }

        [HttpGet]
        public double GameAVGRating()
        {
            return gameLogic.GameAVGRating();
        }

        [HttpGet("{Platform}")]
        public IEnumerable<Game> FindAllGameAtThisPlatform(string Platform)
        {
            return gameLogic.FindAllGameAtThisPlatform(Platform);
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> PlatformICMoney()
        {
            return gameLogic.PlatformICMoney();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> GameCountByPlatform()
        {
            return gameLogic.GameCountByPlatform();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGRatingByPlatform()
        {
            return gameLogic.AVGRatingByPlatform();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByPlatform()
        {
            return gameLogic.AVGPriceByPlatform();
        }
    }
}
