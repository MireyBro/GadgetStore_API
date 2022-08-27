using System.Collections.Generic;

namespace API_GS.Models
{
    public interface IServiceRepository
    {
        IEnumerable<ServiceItem> Get();
        ServiceItem Get(int id);
        void Create(ServiceItem item);
        void Update(ServiceItem item);
        ServiceItem Delete(int id);
    }
}
