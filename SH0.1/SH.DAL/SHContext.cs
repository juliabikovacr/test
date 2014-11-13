using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SH.Models;

namespace SH.DAL
{
    public class SHContext : DbContext, ISHContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Studio> Studios { get; set; }

        public SHContext()
            : base("SHContext")
        {
            Database.SetInitializer<SHContext>(new SHContextInitializer());
            this.Configuration.LazyLoadingEnabled = false;
            this.Studios.Load();
        }
    }
}
