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
    public class ProgramTypeController : Controller
    {
        private readonly ProgramTypeRepository _programTypeRepo = new ProgramTypeRepository();
        private ProgramTypeApp ProgramTypeApp;
        // GET: AdministratorGeneral/ProgramType
        public ActionResult Index()
        {
            List<ProgramTypeApp> ProgramTypeApp = new List<ProgramTypeApp>();

            foreach (ProgramType item in _programTypeRepo.GetAll())
            {
                ProgramTypeApp.Add(Mapper.MapToEntity(item));
            }
            return View(ProgramTypeApp);
        }

        // GET: AdministratorGeneral/ProgramType/Details/5
        public ActionResult Details(int id)
        {
            ProgramTypeApp = Mapper.MapToEntity(_programTypeRepo.GetOne(id));
            return View(ProgramTypeApp);
        }

        // GET: AdministratorGeneral/ProgramType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministratorGeneral/ProgramType/Create
        [HttpPost]
        public ActionResult Create(ProgramTypeApp collection)
        {
            ProgramType Level = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _programTypeRepo.Create(Level);
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

        // GET: AdministratorGeneral/ProgramType/Edit/5
        public ActionResult Edit(int id)
        {
            ProgramTypeApp = Mapper.MapToEntity(_programTypeRepo.GetOne(id));
            return View(ProgramTypeApp);
        }

        // POST: AdministratorGeneral/ProgramType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProgramTypeApp collection)
        {
            ProgramType ProgramType = Mapper.MapToEntity(collection);
            try
            {
                if (ModelState.IsValid)
                {
                    _programTypeRepo.Update(id, ProgramType);
                }
                RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ProgramTypeApp = Mapper.MapToEntity(_programTypeRepo.GetOne(id));
                return View(ProgramTypeApp);
            }
            return RedirectToAction("Index");
        }

        // GET: AdministratorGeneral/ProgramType/Delete/5
        public ActionResult Delete(int id)
        {
            ProgramTypeApp = Mapper.MapToEntity(_programTypeRepo.GetOne(id));
            return View(ProgramTypeApp);
        }

        // POST: AdministratorGeneral/ProgramType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _programTypeRepo.Delete(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ProgramTypeApp = Mapper.MapToEntity(_programTypeRepo.GetOne(id));
                return View(ProgramTypeApp);
            }

            return RedirectToAction("Index");
        }
    }
}
