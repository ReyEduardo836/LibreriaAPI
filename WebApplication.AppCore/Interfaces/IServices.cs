using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.AppCore.Interfaces
{
    public interface IServices <T>
    {
        int Create(T t);
        int Update(T t);
        bool Delete(T t);
        IEnumerable<T> GetAll();
    }
}
