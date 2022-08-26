using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace API_GS.Models
{
    public class ServiceItems
    {
        [Required]
        public Guid Id { get; set; }
        public  string Title { get; set; } 
        public  string Subtitle { get; set; }        
        public  string Text { get; set; }
    }
}
