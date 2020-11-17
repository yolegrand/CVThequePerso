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
    public class LanguageLevelController : Controller
    {
        private readonly LanguageLevelRepository _languageLevelRepo = new LanguageLevelRepository();
        private LanguageLevelApp LanguageLevelApp;
        // GET: AdministratorGeneral/LanguageLevel
        public ActionResult Index()
        {
            List<LanguageLevelApp> LanguageLevelApp = new List<LanguageLevelApp>();

            foreach (LanguageLevel item in _languageLevelRepo.GetAll())
            {
                LanguageLevelApp.Add(Mapper.MapToEntity(item));
            }
            return View(LanguageLevelApp);
        }

        // GET: AdministratorGeneral/LanguageLevel/Details/5
        public ActionResult Details(int id)
        {
            LanguageLevelApp = Mapper.MapToEntity(_languageLevelRepo.GetOne(id));
            return View(LanguageLevelApp);
        }

        // GET: AdministratorGeneral/LanguageLevel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministratorGeneral/LanguageLevel/Create
        [HttpPost]
        public ActionResult Create(LanguageLevelApp collection)
        {
            LanguageLevel Level = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _languageLevelRepo.Create(Level);
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

        // GET: AdministratorGeneral/LanguageLevel/Edit/5
        public ActionResult Edit(int id)
        {
            LanguageLevelApp = Mapper.MapToEntity(_languageLevelRepo.GetOne(id));
            return View(LanguageLevelApp);
        }

        // POST: AdministratorGeneral/LanguageLevel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LanguageLevelApp collection)
        {
            LanguageLevel LanguageLevel = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _languageLevelRepo.Update(id, LanguageLevel);
                }
                RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                LanguageLevelApp = Mapper.MapToEntity(_languageLevelRepo.GetOne(id));
                return View(LanguageLevelApp);
            }
            return RedirectToAction("Index");
        }

        // GET: AdministratorGeneral/LanguageLevel/Delete/5
        public ActionResult Delete(int id)
        {
            LanguageLevelApp = Mapper.MapToEntity(_languageLevelRepo.GetOne(id));
            return View(LanguageLevelApp);
        }

        // POST: AdministratorGeneral/LanguageLevel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _languageLevelRepo.Delete(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                LanguageLevelApp = Mapper.MapToEntity(_languageLevelRepo.GetOne(id));
                return View(LanguageLevelApp);
            }

            return RedirectToAction("Index");
        }
    }
}
