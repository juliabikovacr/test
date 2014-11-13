using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Models
{
    public interface IStorage<T>
    {
        T GetByID(int id);
        List<T> GetAll();
        void Update(T item);
        void Delete(int id);
        void Add(T item);
    }
}
