using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHPYQ8_HFT_2021222.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(int id);
        IQueryable<T> ReadAll();
    }
}
