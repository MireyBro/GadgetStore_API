using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API_GS.Models;

namespace API_GS.Domain.EF
{
    public class EFShopItemRepository : IShopItemRepository
    {

        private EFGsDBContext Context;
        public IEnumerable<ShopItem> Get()
        {
            return Context.ShopItems;
        }
        public ShopItem Get(int Id)
        {
            return Context.ShopItems.Find(Id);
        }
        public EFShopItemRepository(EFGsDBContext context)
        {
            Context = context;
        }
        public void Create(ShopItem item)
        {
            Context.ShopItems.Add(item);
            Context.SaveChanges();
        }
        public void Update(ShopItem updatedServiceItem)
        {
            ShopItem currentItem = Get(updatedServiceItem.ItemId);
            currentItem.Title = updatedServiceItem.Title;
            currentItem.Text = updatedServiceItem.Text;
            currentItem.Image = updatedServiceItem.Image;

            Context.ShopItems.Update(currentItem);
            Context.SaveChanges();
        }

        public ShopItem Delete(int Id)
        {
            ShopItem todoItem = Get(Id);

            if (todoItem != null)
            {
                Context.ShopItems.Remove(todoItem);
                Context.SaveChanges();
            }

            return todoItem;
        }
    }
}
