using System.Collections.Generic;
using API_GS.Models;
using API_GS.Domain.EF.Conections;

namespace API_GS.Domain.EF
{
    public class EFShopItemRepository : IShopItemRepository
    {

        private EFGsDBContext Context;
        public EFShopItemRepository(EFGsDBContext context)
        {
            Context = context;
        }
        public IEnumerable<ShopItem> Get()
        {
            return Context.ShopItems;
        }
        public ShopItem Get(int Id)
        {
            return Context.ShopItems.Find(Id);
        }
        public void Create(ShopItem item)
        {
            Context.ShopItems.Add(item);
            Context.SaveChanges();
        }
        public void Update(ShopItem updatedItem)
        {
            ShopItem currentItem = Get(updatedItem.ItemId);
            currentItem.Title = updatedItem.Title;
            currentItem.Text = updatedItem.Text;
            currentItem.Image = updatedItem.Image;

            Context.ShopItems.Update(currentItem);
            Context.SaveChanges();
        }

        public ShopItem Delete(int Id)
        {
            ShopItem item = Get(Id);

            if (item != null)
            {
                Context.ShopItems.Remove(item);
                Context.SaveChanges();
            }

            return item;
        }
    }
}
