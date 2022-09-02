using API_GS.Domain.EF.Entities;
using System;
using System.Collections.Generic;

namespace API_GS.Domain.Abstract
{
    public interface ITimeTableRepository
    {
        IEnumerable<TimeTable> Get();
        TimeTable Get(int id);
        void Create(TimeTable table);
        void Update(TimeTable table);
        TimeTable Delete(int id);
        
    }
}
