using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHPYQ8_HFT_2021222.Models;
using UHPYQ8_HFT_2021222.Repository.Interface;

namespace UHPYQ8_HFT_2021222.Logic.Classes
{
    public class GameLogic : IGameLogic
    {
        IRepository<Game> repo;

        public GameLogic(IRepository<Game> repo)
        {
            this.repo = repo;
        }

        public void Create(Game item)
        {
            if (item.Title.Length < 3)
            {
                throw new ArgumentException("Not enough long title.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Game Read(int id)
        {
            var game = this.repo.Read(id);
            if (game == null)
            {
                throw new ArgumentException("This game not exists");
            }
            return game;
        }

        public IQueryable<Game> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Game item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<KeyValuePair<string, double>> AVGPriceByPlatform()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Platform.PlatformName into g
                   select new KeyValuePair<string, double>
                  (g.Key, g.Average(t => t.Price));
        }
        public IEnumerable<KeyValuePair<string, double>> AVGRatingByPlatform()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Platform.PlatformName into g
                   select new KeyValuePair<string, double>
                  (g.Key, g.Average(t => t.Rating));
        }
        public IEnumerable<KeyValuePair<string, double>> GameCountByPlatform()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Platform.PlatformName into g
                   select new KeyValuePair<string, double>
                  (g.Key, g.Count());
        }
        public IEnumerable<KeyValuePair<string, double>> PlatformICMoney()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Platform.PlatformName into g
                   select new KeyValuePair<string, double>
                  (g.Key, g.Sum(t => t.Price));
        }
    }
}
