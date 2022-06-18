using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Interfaces
{
    public interface IRepository<T>
    {
        int Create(T t);
        int Update(T t);
        bool Delete(T t);
        IEnumerable<T> GetAll();
    }
}
