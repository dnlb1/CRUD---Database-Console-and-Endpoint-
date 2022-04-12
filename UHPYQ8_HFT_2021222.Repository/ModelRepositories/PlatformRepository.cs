using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHPYQ8_HFT_2021222.Models;
using UHPYQ8_HFT_2021222.Repository.GenericRepository;
using UHPYQ8_HFT_2021222.Repository.Interface;

namespace UHPYQ8_HFT_2021222.Repository.ModelRepositories
{
    public class PlatformRepository : Repository<Platform>, IRepository<Platform>
    {
        public PlatformRepository(GameDbContext ctx) : base(ctx)
        {
        }

        public override Platform Read(int id)
        {
            return ctx.Platforms.FirstOrDefault(t => t.PlatformId == id);
        }

        public override void Update(Platform item)
        {
            var old = Read(item.PlatformId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
