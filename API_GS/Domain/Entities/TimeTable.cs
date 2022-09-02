using System;
using System.ComponentModel.DataAnnotations;

namespace API_GS.Domain.EF.Entities
{
    public class TimeTable
    {
        [Key]
        public int TimeTableId { get; set; }
        public string Day { get; set; }
        public string TimeOpened { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
