using System.ComponentModel.DataAnnotations;

namespace API_GS.Domain.EF.Entities
{
    public class ShopItem
    {
        [Key]
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
    }
}
