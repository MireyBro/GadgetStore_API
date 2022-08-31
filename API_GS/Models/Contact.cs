using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace API_GS.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Adress { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string FacebookLink { get; set; }
        public string InstaLink { get; set; }


    }
}
