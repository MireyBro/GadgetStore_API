using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace API_GS.Models
{
    public class ServiceItem
    {
        public int Id { get; set; }
        public  string Title { get; set; }       
        public  string Text { get; set; }
    }
}
