using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHPYQ8_HFT_2021222.Repository.Interface;

namespace UHPYQ8_HFT_2021222.Repository.GenericRepository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
    }
}
