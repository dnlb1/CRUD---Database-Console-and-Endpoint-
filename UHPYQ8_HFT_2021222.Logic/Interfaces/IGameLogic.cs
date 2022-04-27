using System.Collections.Generic;
using System.Linq;
using UHPYQ8_HFT_2021222.Models;

namespace UHPYQ8_HFT_2021222.Logic.Interfaces
{
    public interface IGameLogic
    {
        IEnumerable<KeyValuePair<string, double>> AVGPriceByPlatform();
        IEnumerable<KeyValuePair<string, double>> AVGRatingByPlatform();
        void Create(Game item);
        void Delete(int id);
        IEnumerable<Game> FindAllGameAtThisPlatform(string PlatformName);
        double GameAVGPrice();
        double GameAVGRating();
        IEnumerable<KeyValuePair<string, double>> GameCountByPlatform();
        IEnumerable<KeyValuePair<string, double>> PlatformICMoney();
        Game Read(int id);
        IQueryable<Game> ReadAll();
        void Update(Game item);
    }
}