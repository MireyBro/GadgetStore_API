using API_GS.Domain.Entities.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_GS.Services
{
    public interface IEFRepository<T> where T : BaseEntity
    {       
        List<T> GetAll();
        T GetById(long id);
        Task<long> Add(T entity);
    }
}

