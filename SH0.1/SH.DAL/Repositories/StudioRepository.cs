using Ninject;
using SH.DAL.Interfaces;
using SH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.DAL.Repositories
{
    public class StudioRepository : IStudioRepository
    {
        private ISHContext context;

        [Inject]
        public StudioRepository(ISHContext context)
        {
            this.context = context;
        }

        public List<Studio> GetAll()
        {
            return context.Studios.ToList();
        }

        public Studio GetByID(int id)
        {
            return context.Studios.FirstOrDefault(x=>x.ID == id);
        }

        public void Update(Studio item)
        {
            Studio s = context.Studios.First(x=>x.ID == item.ID);
            s.Name = item.Name;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Studios.Remove(context.Studios.First(x => x.ID == id));
            context.SaveChanges();
        }

        public void Add(Studio item)
        {
            context.Studios.Add(item);
            context.SaveChanges();
        }
    }
}