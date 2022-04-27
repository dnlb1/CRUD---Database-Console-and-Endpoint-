using System.Linq;
using UHPYQ8_HFT_2021222.Models;

namespace UHPYQ8_HFT_2021222.Logic.Classes
{
    public interface IPlatformLogic
    {
        void Create(Platform item);
        void Delete(int id);
        Platform Read(int id);
        IQueryable<Platform> ReadAll();
        void Update(Platform item);
    }
}