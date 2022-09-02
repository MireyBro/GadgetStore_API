using API_GS.Domain.EF.Entities;
using System.Collections.Generic;

namespace API_GS.Models
{
    public interface IShopItemRepository
    {
        IEnumerable<ShopItem> Get();
        ShopItem Get(int id);
        void Create(ShopItem item);
        void Update(ShopItem item);
        ShopItem Delete(int id);
    }
}
