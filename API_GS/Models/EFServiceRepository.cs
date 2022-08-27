using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API_GS.Models;
namespace API_GS.Models
{
    public class EFServiceRepository : IServiceRepository
    {

        private EFServiceDBContext Context;
        public IEnumerable<ServiceItem> Get()
        {
            return Context.ServiceItems;
        }
        public ServiceItem Get(int Id)
        {
            return Context.ServiceItems.Find(Id);
        }
        public EFServiceRepository(EFServiceDBContext context)
        {
            Context = context;
        }
        public void Create(ServiceItem item)
        {
            Context.ServiceItems.Add(item);
            Context.SaveChanges();
        }
        public void Update(ServiceItem updatedServiceItem)
        {
            ServiceItem currentItem = Get(updatedServiceItem.Id);
            currentItem.Title = updatedServiceItem.Title;
            currentItem.Text=updatedServiceItem.Text;

            Context.ServiceItems.Update(currentItem);
            Context.SaveChanges();
        }

        public ServiceItem Delete(int Id)
        {
            ServiceItem todoItem = Get(Id);

            if (todoItem != null)
            {
                Context.ServiceItems.Remove(todoItem);
                Context.SaveChanges();
            }

            return todoItem;
        }
    }
}
