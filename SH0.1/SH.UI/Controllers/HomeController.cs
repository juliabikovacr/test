using Newtonsoft.Json;
using Ninject;
using SH.BAL.Storages;
using SH.Models;
using SH.Models.ViewModels;
using SH.UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SH.UI.Controllers
{
    public class HomeController : Controller
    {
        private IStorage<Hero> heroStorage;
        private IStorage<Studio> studioStorage;

        [Inject]
        public HomeController(IStorage<Hero> heroStorage, IStorage<Studio> studioStorage)
        {
            this.heroStorage = heroStorage;
            this.studioStorage = studioStorage;
        }

        public ActionResult Index()
        {
            return View();
        }

        public string GetData()
        {
            return JsonConvert.SerializeObject(new { data = heroStorage.GetAll() });
        }

        public void DeleteHero(int ID)
        {
            heroStorage.Delete(ID);
        }

        [HttpPost]
        public void DeleteStudio(int id)
        {
            foreach (var item in heroStorage.GetAll().FindAll(x=>x.StudioID == id))
            {
                heroStorage.Delete(item.ID);
            }
            studioStorage.Delete(id);
        }

        [HttpGet]
        public ActionResult GetHeroPartial()
        {
            ViewData.Add("ActionMethod", "AddHero");
            return PartialView("Hero", new Hero());
        }

        [HttpGet]
        public ActionResult Studio(int? id)
        {
            StudioHeroesModel model = new StudioHeroesModel();
            if (!id.HasValue)
            {
                ViewData.Add("ActionMethod", "add");
                model.Studio = new Studio();
                model.Heroes = new List<Hero>();
            }
            else
            {
                ViewData.Add("ActionMethod", "edit");
                model.Studio = studioStorage.GetByID(id.Value);
                model.Heroes = heroStorage.GetAll().FindAll(x=>x.StudioID == id);
            }
            return View("AddEditStudio", model);
        }

        [HttpPost]
        public void Studio(StudioHeroesModel model)
        {
            if (model.Studio.ID == 0)
            {
                studioStorage.Add(model.Studio);
            }
            else
            {
                studioStorage.Update(model.Studio);
            }
            if(model.Heroes!=null)
            foreach (var item in model.Heroes)
            {
                item.StudioID = model.Studio.ID;
                if (item.ID == 0)
                {
                    heroStorage.Add(item);
                }
                else
                {
                    heroStorage.Update(item);
                }
            }
            Response.Redirect("/");
        }

        [HttpGet]
        public ActionResult Hero(int? id)
        {
            Hero model;
            ViewData.Add("Studios", studioStorage.GetAll());
            if (id.HasValue)
            {
                model = heroStorage.GetByID(id.Value);
                ViewData.Add("ActionMethod", "edit");
            }
            else
            {
                model = new Hero();
                ViewData.Add("ActionMethod", "add");
            }
            return View("AddEditHero", model);
        }

        [HttpPost]
        public void Hero(Hero model)
        {
            if (model.ID == 0)
            {
                heroStorage.Add(model);
            }
            else
            {
                heroStorage.Update(model);
            }
            Response.Redirect("/");
        }
    }
}
