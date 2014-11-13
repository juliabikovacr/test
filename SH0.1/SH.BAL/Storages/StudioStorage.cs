using SH.DAL.Repositories;
using SH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace SH.BAL.Storages
{
    public class StudioStorage : IStorage<Studio>
    {
        private IRepository<Studio> studioRepository;

        [Inject]
        public StudioStorage(IRepository<Studio> studioRepository)
        {
            this.studioRepository = studioRepository;
        }
        public List<Studio> GetAll()
        {
            return studioRepository.GetAll();
        }

        public Studio GetByID(int id)
        {
            return studioRepository.GetByID(id);
        }

        public void Update(Studio item)
        {
            studioRepository.Update(item);
        }

        public void Delete(int id)
        {
            studioRepository.Delete(id);
        }

        public void Add(Studio item)
        {
            studioRepository.Add(item);
        }
    }
}
