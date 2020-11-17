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
    public class KnowledgeTypeController : Controller
    {
        private readonly KnowledgeTypeRepository _knowledgeRepo = new KnowledgeTypeRepository();
        private KnowledgeTypeApp KnowledgeTypeApp;
        // GET: AdministratorGeneral/KnowledgeType
        public ActionResult Index()
        {
            List<KnowledgeTypeApp> KnowledgeTypeApp = new List<KnowledgeTypeApp>();

            foreach (KnowledgeType item in _knowledgeRepo.GetAll())
            {
                KnowledgeTypeApp.Add(Mapper.MapToEntity(item));
            }
            return View(KnowledgeTypeApp);
        }

        // GET: AdministratorGeneral/KnowledgeType/Details/5
        public ActionResult Details(int id)
        {
            KnowledgeTypeApp = Mapper.MapToEntity(_knowledgeRepo.GetOne(id));
            return View(KnowledgeTypeApp);
        }

        // GET: AdministratorGeneral/KnowledgeType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministratorGeneral/KnowledgeType/Create
        [HttpPost]
        public ActionResult Create(KnowledgeTypeApp collection)
        {
            KnowledgeType Level = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _knowledgeRepo.Create(Level);
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

        // GET: AdministratorGeneral/KnowledgeType/Edit/5
        public ActionResult Edit(int id)
        {
            KnowledgeTypeApp = Mapper.MapToEntity(_knowledgeRepo.GetOne(id));
            return View(KnowledgeTypeApp);
        }

        // POST: AdministratorGeneral/KnowledgeType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KnowledgeTypeApp collection)
        {
            KnowledgeType ProgramType = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _knowledgeRepo.Update(id, ProgramType);
                }
                RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                KnowledgeTypeApp = Mapper.MapToEntity(_knowledgeRepo.GetOne(id));
                return View(KnowledgeTypeApp);
            }
            return RedirectToAction("Index");
        }

        // GET: AdministratorGeneral/KnowledgeType/Delete/5
        public ActionResult Delete(int id)
        {
            KnowledgeTypeApp = Mapper.MapToEntity(_knowledgeRepo.GetOne(id));
            return View(KnowledgeTypeApp);
        }

        // POST: AdministratorGeneral/KnowledgeType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _knowledgeRepo.Delete(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                KnowledgeTypeApp = Mapper.MapToEntity(_knowledgeRepo.GetOne(id));
                return View(KnowledgeTypeApp);
            }

            return RedirectToAction("Index");
        }
    }
}
