using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SH.Models;

namespace SH.DAL
{
    class SHContextInitializer : DropCreateDatabaseIfModelChanges<SHContext>
    {
        protected override void Seed(SHContext context)
        {
            context.Studios.Add(new Studio() { Name = "Marvel"});
            context.Studios.Add(new Studio() { Name = "DC"});
            context.SaveChanges();

            context.Heroes.Add(new Hero() 
            {
                Name = "Spider Man",
                Year = 1969,
                Studio = context.Studios.First(x=>x.Name.Equals("Marvel"))
            });
            context.Heroes.Add(new Hero() 
            {
                Name = "Deadpool",
                Year = 1987,
                Studio = context.Studios.First(x=>x.Name.Equals("Marvel"))
            });
            context.Heroes.Add(new Hero() 
            {
                Name = "Batman",
                Year = 1963,
                Studio = context.Studios.First(x=>x.Name.Equals("DC"))
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
