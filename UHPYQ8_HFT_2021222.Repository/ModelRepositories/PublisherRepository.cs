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
    public class PublisherRepository : Repository<Publisher>, IRepository<Publisher>
    {
        public PublisherRepository(GameDbContext ctx) : base(ctx)
        {
        }

        public override Publisher Read(int id)
        {
            return ctx.Publishers.FirstOrDefault(t => t.PublisherId == id);
        }

        public override void Update(Publisher item)
        {
            var old = Read(item.PublisherId);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
