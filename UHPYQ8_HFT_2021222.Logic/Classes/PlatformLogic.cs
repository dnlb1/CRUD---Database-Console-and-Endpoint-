using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHPYQ8_HFT_2021222.Models;
using UHPYQ8_HFT_2021222.Repository.Interface;

namespace UHPYQ8_HFT_2021222.Logic.Classes
{
    public class PlatformLogic : IPlatformLogic
    {
        IRepository<Platform> repo;

        public PlatformLogic(IRepository<Platform> repo)
        {
            this.repo = repo;
        }

        public void Create(Platform item)
        {
            if (item.PlatformName.Length < 2)
            {
                throw new ArgumentException("Not enough long Platform name.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Platform Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Platform> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Platform item)
        {
            this.repo.Update(item);
        }
    }
}
