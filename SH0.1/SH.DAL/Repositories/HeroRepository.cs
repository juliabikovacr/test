using SH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Ninject;
using SH.DAL.Interfaces;

namespace SH.DAL.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private ISHContext context;

        [Inject]
        public HeroRepository(ISHContext context)
        {
            this.context = context;
        }
        public Hero GetByID(int id)
        {
            return context.Heroes.FirstOrDefault(x => x.ID == id);
        }

        public List<Hero> GetAll()
        {
            return context.Heroes.ToList();
        }

        public void Add(Hero item)
        {
            context.Heroes.Add(new Hero()
            {
                Name = item.Name,
                StudioID = item.StudioID,
                Year = item.Year
            });
            context.SaveChanges();
        }

        public void Update(Hero item)
        {
            var hero = context.Heroes.First(x => x.ID == item.ID);
            hero.Name = item.Name;
            hero.Year = item.Year;
            hero.StudioID = item.StudioID;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Heroes.Remove(context.Heroes.First(x => x.ID == id));
            context.SaveChanges();
        }
    }
}
