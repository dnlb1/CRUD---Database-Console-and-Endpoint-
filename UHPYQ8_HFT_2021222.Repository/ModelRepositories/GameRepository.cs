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
    public class GameRepository : Repository<Game>, IRepository<Game>
    {
        public GameRepository(GameDbContext ctx) : base(ctx)
        {
        }

        public override Game Read(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Game item)
        {
            throw new NotImplementedException();
        }
    }
}
