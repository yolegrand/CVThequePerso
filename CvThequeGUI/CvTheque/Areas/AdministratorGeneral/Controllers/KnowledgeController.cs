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
    public class KnowledgeController : Controller
    {
        private readonly KnowledgeRepository _knowledgeRepo = new KnowledgeRepository();
        private KnowledgeApp KnowledgeApp;
        // GET: AdministratorGeneral/Knowledge
        public ActionResult Index()
        {
            List<KnowledgeApp> KnowledgeApp = new List<KnowledgeApp>();

            foreach (Knowledge item in _knowledgeRepo.GetAll())
            {
                KnowledgeApp.Add(Mapper.MapToEntity(item));
            }
            return View(KnowledgeApp);
        }

        // GET: AdministratorGeneral/Knowledge/Details/5
        public ActionResult Details(int id)
        {
            KnowledgeApp = Mapper.MapToEntity(_knowledgeRepo.GetOne(id));
            return View(KnowledgeApp);
        }

        // GET: AdministratorGeneral/Knowledge/Create
        public ActionResult Create()
        {
            KnowledgeTypeRepository KnowledgeTypeRepository = new KnowledgeTypeRepository();
            ViewBag.KnowledgeType = new SelectList(KnowledgeTypeRepository.GetAll(), "Id", "Name", "SelectdValue");
            return View();
        }

        // POST: AdministratorGeneral/Knowledge/Create
        [HttpPost]
        public ActionResult Create(KnowledgeApp collection)
        {
            Knowledge Knowledge = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _knowledgeRepo.Create(Knowledge);
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

        // GET: AdministratorGeneral/Knowledge/Edit/5
        public ActionResult Edit(int id)
        {
            KnowledgeTypeRepository KnowledgeTypeRepository = new KnowledgeTypeRepository();
            ViewBag.KnowledgeType = new SelectList(KnowledgeTypeRepository.GetAll(), "Id", "Name", "SelectdValue");
            KnowledgeApp = Mapper.MapToEntity(_knowledgeRepo.GetOne(id));
            return View(KnowledgeApp);
        }

        // POST: AdministratorGeneral/Knowledge/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KnowledgeApp collection)
        {
            Knowledge Knowledge = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _knowledgeRepo.Update(id, Knowledge);
                }
                RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                KnowledgeApp = Mapper.MapToEntity(_knowledgeRepo.GetOne(id));
                return View(KnowledgeApp);
            }
            return RedirectToAction("Index");
        }

        // GET: AdministratorGeneral/Knowledge/Delete/5
        public ActionResult Delete(int id)
        {
            KnowledgeApp = Mapper.MapToEntity(_knowledgeRepo.GetOne(id));
            return View(KnowledgeApp);
        }

        // POST: AdministratorGeneral/Knowledge/Delete/5
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
                KnowledgeApp = Mapper.MapToEntity(_knowledgeRepo.GetOne(id));
                return View(KnowledgeApp);
            }

            return RedirectToAction("Index");
        }
    }
}
