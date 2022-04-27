using System.Linq;
using UHPYQ8_HFT_2021222.Models;

namespace UHPYQ8_HFT_2021222.Logic.Classes
{
    public interface IGameLogic
    {
        void Create(Game item);
        void Delete(int id);
        Game Read(int id);
        IQueryable<Game> ReadAll();
        void Update(Game item);
    }
}