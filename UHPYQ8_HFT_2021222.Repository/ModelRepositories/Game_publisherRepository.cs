﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHPYQ8_HFT_2021222.Models;
using UHPYQ8_HFT_2021222.Repository.GenericRepository;
using UHPYQ8_HFT_2021222.Repository.Interface;

namespace UHPYQ8_HFT_2021222.Repository.ModelRepositories
{
    public class Game_publisherRepository : Repository<Game_publisher>, IRepository<Game_publisher>
    {
        public override Game_publisher Read(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Game_publisher item)
        {
            throw new NotImplementedException();
        }
    }
}
