using API_GS.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using System;
using API_GS.Domain.Abstract;
using API_GS.Domain.EF.Entities;

namespace API_GS.Domain
{
    public class EFGsDBContext : DbContext
    {

        public EFGsDBContext(DbContextOptions<EFGsDBContext> options)
        : base(options)
        {
        }

        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }


    }
}
