using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.repository
{
    public interface IRepository<ID, T>
    {
        void add(T elem);
        void update(ID id, int x);
        void delete(ID id);
        IEnumerable<T> findAll();
    }
}
