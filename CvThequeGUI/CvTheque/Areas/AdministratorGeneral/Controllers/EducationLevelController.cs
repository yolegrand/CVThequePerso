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
    public class EducationLevelController : Controller
    {
        private readonly EducationLevelRepository _educationLevelRepo = new EducationLevelRepository();
        private EducationLevelApp EducationLevelApp;
        // GET: AdministratorGeneral/EducationLevel
        public ActionResult Index()
        {
            List<EducationLevelApp> EducationlevelApp = new List<EducationLevelApp>();

            foreach (EducationLevel item in _educationLevelRepo.GetAll())
            {
                EducationlevelApp.Add(Mapper.MapToEntity(item));
            }
            return View(EducationlevelApp);
        }

        // GET: AdministratorGeneral/EducationLevel/Details/5
        public ActionResult Details(int id)
        {
            EducationLevelApp = Mapper.MapToEntity(_educationLevelRepo.GetOne(id));
            return View(EducationLevelApp);
        }

        // GET: AdministratorGeneral/EducationLevel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministratorGeneral/EducationLevel/Create
        [HttpPost]
        public ActionResult Create(EducationLevelApp collection)
        {
            EducationLevel EducationLevel = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _educationLevelRepo.Create(EducationLevel);
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

        // GET: AdministratorGeneral/EducationLevel/Edit/5
        public ActionResult Edit(int id)
        {
            EducationLevelApp = Mapper.MapToEntity(_educationLevelRepo.GetOne(id));
            return View(EducationLevelApp);
        }

        // POST: AdministratorGeneral/EducationLevel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EducationLevelApp collection)
        {
            EducationLevel EducationLevel = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _educationLevelRepo.Update(id, EducationLevel);
                }
                RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                EducationLevelApp = Mapper.MapToEntity(_educationLevelRepo.GetOne(id));
                return View(EducationLevelApp);
            }
            return RedirectToAction("Index");
        }

        // GET: AdministratorGeneral/EducationLevel/Delete/5
        public ActionResult Delete(int id)
        {
            EducationLevelApp = Mapper.MapToEntity(_educationLevelRepo.GetOne(id));
            return View(EducationLevelApp);
        }

        // POST: AdministratorGeneral/EducationLevel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EducationLevelApp collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _educationLevelRepo.Delete(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                EducationLevelApp = Mapper.MapToEntity(_educationLevelRepo.GetOne(id));
                return View(EducationLevelApp);
            }

            return RedirectToAction("Index");
        }
    }
}
