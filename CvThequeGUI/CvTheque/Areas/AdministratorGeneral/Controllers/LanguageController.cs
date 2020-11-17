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
    public class LanguageController : Controller
    {
        private readonly LanguageRepository _languageRepo = new LanguageRepository();
        private LanguageApp LanguageApp;
        // GET: AdministratorGeneral/Language
        public ActionResult Index()
        {
            List<LanguageApp> LanguageApp = new List<LanguageApp>();

            foreach (Language item in _languageRepo.GetAll())
            {
                LanguageApp.Add(Mapper.MapToEntity(item));
            }
            return View(LanguageApp);
        }

        // GET: AdministratorGeneral/Language/Details/5
        public ActionResult Details(int id)
        {
            LanguageApp = Mapper.MapToEntity(_languageRepo.GetOne(id));
            return View(LanguageApp);
        }

        // GET: AdministratorGeneral/Language/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministratorGeneral/Language/Create
        [HttpPost]
        public ActionResult Create(LanguageApp collection)
        {
            Language Language = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _languageRepo.Create(Language);
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

        // GET: AdministratorGeneral/Language/Edit/5
        public ActionResult Edit(int id)
        {
            LanguageApp = Mapper.MapToEntity(_languageRepo.GetOne(id));
            return View(LanguageApp);
        }

        // POST: AdministratorGeneral/Language/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LanguageApp collection)
        {
            Language Language = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _languageRepo.Update(id, Language);
                }
                RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                LanguageApp = Mapper.MapToEntity(_languageRepo.GetOne(id));
                return View(LanguageApp);
            }
            return RedirectToAction("Index");
        }

        // GET: AdministratorGeneral/Language/Delete/5
        public ActionResult Delete(int id)
        {
            LanguageApp = Mapper.MapToEntity(_languageRepo.GetOne(id));
            return View(LanguageApp);
        }

        // POST: AdministratorGeneral/Language/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _languageRepo.Delete(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                LanguageApp = Mapper.MapToEntity(_languageRepo.GetOne(id));
                return View(LanguageApp);
            }

            return RedirectToAction("Index");
        }
    }
}
