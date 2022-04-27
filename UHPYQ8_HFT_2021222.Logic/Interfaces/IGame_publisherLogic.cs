using System.Linq;
using UHPYQ8_HFT_2021222.Models;

namespace UHPYQ8_HFT_2021222.Logic.Interfaces
{
    public interface IGame_publisherLogic
    {
        void Create(Game_publisher item);
        void Delete(int id);
        Game_publisher Read(int id);
        IQueryable<Game_publisher> ReadAll();
        void Update(Game_publisher item);
    }
}