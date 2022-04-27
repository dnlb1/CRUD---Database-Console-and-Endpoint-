using System.Linq;
using UHPYQ8_HFT_2021222.Models;

namespace UHPYQ8_HFT_2021222.Logic.Interfaces
{
    public interface IPublisherLogic
    {
        void Create(Publisher item);
        void Delete(int id);
        Publisher Read(int id);
        IQueryable<Publisher> ReadAll();
        void Update(Publisher item);
    }
}