using Ninject;
using SH.DAL.Repositories;
using SH.Models;
using SH.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.BAL.Storages
{
    public class HeroStorage : IStorage<Hero>
    {
        private IRepository<Hero> heroRepository;
        [Inject]
        public HeroStorage(IRepository<Hero> heroRepository)
        {
            this.heroRepository = heroRepository;
        }

        public void Add(Hero item)
        {
            heroRepository.Add(item);
        }

        public Hero GetByID(int id)
        {
            return heroRepository.GetByID(id);
        }

        public void Update(Hero item)
        {
            heroRepository.Update(item);
        }

        public List<Hero> GetAll()
        {
            return heroRepository.GetAll();
        }


        public void Delete(int id)
        {
            heroRepository.Delete(id);
        }
    }
}
