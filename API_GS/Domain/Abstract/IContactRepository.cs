using API_GS.Models;
using System.Collections.Generic;

namespace API_GS.Domain.Abstract
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get();
        Contact Get(int id);
        void Create(Contact contact);
        void Update(Contact contact);
        Contact Delete(int id);
    }
}
