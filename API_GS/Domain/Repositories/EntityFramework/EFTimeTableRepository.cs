using API_GS.Domain.Abstract;
using API_GS.Domain.EF.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace API_GS.Domain.EF
{
    public class EFTimeTableRepository : ITimeTableRepository
    {
        private EFGsDBContext Context;

        public EFTimeTableRepository(EFGsDBContext context)
        {
            Context = context;
        }


        public void Create(TimeTable table)
        {
            Context.TimeTables.Add(table);
            Context.SaveChanges();
        }

        public TimeTable Delete(int id)
        {
            TimeTable deleteTable = Get(id);
            if (deleteTable != null)
            {
                Context.TimeTables.Remove(deleteTable);
                Context.SaveChanges();
            }
            return deleteTable;
        }

        public IEnumerable<TimeTable> Get()
        {
            return Context.TimeTables;
        }

        public TimeTable Get(int id)
        {
            return Context.TimeTables.Find(id);
        }

        public void Update(TimeTable modifiedTimeTable)
        {
            TimeTable currentTimeTable = Get(modifiedTimeTable.TimeTableId);
            currentTimeTable.Day = modifiedTimeTable.Day;
            currentTimeTable.TimeOpened = modifiedTimeTable.TimeOpened;
            

            Context.TimeTables.Update(currentTimeTable);
            Context.SaveChanges();
        }
    }
}
