using CvTheque.Models;
using CvTheque.Services;
using DalHttp.core.Models;
using DalHttp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvTheque.Areas.AdministratorGeneral.Controllers
{
    public class LevelController : Controller
    {
        private readonly LevelRepository _LevelRepo = new LevelRepository();
        private LevelApp LevelApp;
        // GET: AdministratorGeneral/Level
        public ActionResult Index()
        {
            List<LevelApp> levelApp = new List<LevelApp>();

            foreach (Level item in _LevelRepo.GetAll())
            {
                levelApp.Add(Mapper.MapToEntity(item));
            }
            return View(levelApp);
        }

        // GET: AdministratorGeneral/Level/Details/5
        public ActionResult Details(int id)
        {
            LevelApp = Mapper.MapToEntity(_LevelRepo.GetOne(id));
            return View(LevelApp);
        }

        // GET: AdministratorGeneral/Level/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministratorGeneral/Level/Create
        [HttpPost]
        public ActionResult Create(LevelApp collection)
        {
            Level Level = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _LevelRepo.Create(Level);
                }
                RedirectToAction("index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }

            return RedirectToAction("Index");
        }

        // GET: AdministratorGeneral/Level/Edit/5
        public ActionResult Edit(int id)
        {
            LevelApp = Mapper.MapToEntity(_LevelRepo.GetOne(id));
            return View(LevelApp);
        }

        // POST: AdministratorGeneral/Level/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LevelApp collection)
        {
            Level Level = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _LevelRepo.Update(id, Level);
                }
                RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                LevelApp = Mapper.MapToEntity(_LevelRepo.GetOne(id));
                return View(LevelApp);
            }
            return RedirectToAction("Index");
        }

        // GET: AdministratorGeneral/Level/Delete/5
        public ActionResult Delete(int id)
        {
            LevelApp = Mapper.MapToEntity(_LevelRepo.GetOne(id));
            return View(LevelApp);
        }

        // POST: AdministratorGeneral/Level/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _LevelRepo.Delete(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                LevelApp = Mapper.MapToEntity(_LevelRepo.GetOne(id));
                return View(LevelApp);
            }

            return RedirectToAction("Index");
        }
    }
}
