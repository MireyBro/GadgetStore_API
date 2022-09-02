using API_GS.Domain.Abstract;
using System.Collections.Generic;
using API_GS.Domain.EF.Entities;

namespace API_GS.Domain.EF
{
    public class EFContactRepository : IContactRepository
    {
        private readonly EFGsDBContext Context;
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
        public void Update(Contact updatedContact)
        {
            Contact currentContact = Get(updatedContact.ContactId);
            currentContact.Adress = updatedContact.Adress;
            currentContact.Phone1 = updatedContact.Phone1;
            currentContact.Phone2 = updatedContact.Phone2;
            currentContact.FacebookLink= updatedContact.FacebookLink;
            currentContact.InstaLink= updatedContact.InstaLink;

            Context.Contacts.Update(currentContact);
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
