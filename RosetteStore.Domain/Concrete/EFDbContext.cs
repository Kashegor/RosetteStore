using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosetteStore.Domain.Entities;

namespace RosetteStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        //public EFDbContext()
        //{
        //    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDbContext>());
        //}

        public DbSet<Rosette> Rosettes { get; set; }
    }
}
