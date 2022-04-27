using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHPYQ8_HFT_2021222.Models;
using UHPYQ8_HFT_2021222.Repository.Interface;

namespace UHPYQ8_HFT_2021222.Logic.Classes
{
    public class Game_publisherLogic
    {
        IRepository<Game_publisher> repo;

        public Game_publisherLogic(IRepository<Game_publisher> repo)
        {
            this.repo = repo;
        }

        public void Create(Game_publisher item)
        {
            if (item.release_year < 1945)
            {
                throw new ArgumentException("This type of game not exists");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Game_publisher Read(int id)
        {
            var Game_publisher = this.repo.Read(id);
            if (Game_publisher == null)
            {
                throw new ArgumentException("This Game publisher not exists");
            }
            return Game_publisher;
        }

        public IQueryable<Game_publisher> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Game_publisher item)
        {
            this.repo.Update(item);
        }
    }
}
