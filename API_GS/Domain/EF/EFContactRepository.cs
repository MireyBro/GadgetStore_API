using API_GS.Domain.Abstract;
using API_GS.Domain.EF.Conections;
using System.Collections.Generic;
using API_GS.Models;

namespace API_GS.Domain.EF
{
    public class EFContactRepository : IContactRepository
    {
        private EFGsDBContext Context;
        public EFContactRepository(EFGsDBContext context)
        {
            Context = context;
        }

        public IEnumerable<Contact> Get()
        {
            return Context.Contacts;
        }
        public Contact Get(int Id)
        {
            return Context.Contacts.Find(Id);
        }
        public void Create(Contact contact)
        {
            Context.Contacts.Add(contact);
            Context.SaveChanges();
        }
        public void Update(Contact contact)
        {
            Context.Contacts.Update(contact);
            Context.SaveChanges();
        }
        public Contact Delete(int id)
        {
            Contact contact = Get(id);
            if(contact != null)
            {
                Context.Contacts.Remove(contact);
                Context.SaveChanges();
            }
            return contact;
        }
        
    }
}
