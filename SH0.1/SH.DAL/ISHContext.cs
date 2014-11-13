using SH.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.DAL
{
    public interface ISHContext : IDisposable
    {
        DbSet<Hero> Heroes { get; set; }
        DbSet<Studio> Studios { get; set; }

        int SaveChanges();
    }
}
