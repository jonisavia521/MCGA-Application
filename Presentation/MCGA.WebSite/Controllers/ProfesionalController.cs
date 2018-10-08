using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MCGA.Entities;
using MCGA.UI.Process;
using MCGA.WebSite.Constants.ProfesionalController;
using MCGA.WebSite.Models;
using PagedList;

namespace MCGA.WebSite.Controllers
{
    public class ProfesionalController : Controller
    {
        public ProfesionalController()
        {
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<List<Profesional>, List<ProfesionalVM>>();
            //    cfg.CreateMap<Profesional, ProfesionalVM>();
            //});
        }
        private ProfesionalProcess db = new ProfesionalProcess();

        // GET: Profesional
        [Route("lista-profesionales", Name = ProfesionalControllerRoute.GetIndex)]
        public ActionResult Index()
        {
            
            List<Profesional> profesionales = db.getProfesionales();
            //List<ProfesionalVM> profesionalVM = Mapper.Map<List<ProfesionalVM>>(profesionales);
            return View(profesionales);
        }
        public ActionResult List(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;
            IEnumerable<Profesional> pros = db.getProfesionales();
            if (!string.IsNullOrEmpty(searchString))
            {
                pros = pros.Where(s => s.Nombre.ToLower().Contains(searchString.ToLower()));
            }
            pros = pros.OrderBy(s => s.Id);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(pros.ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult List()
        //{
        //    List<Profesional> profesionales = db.getProfesionales();
        //    return View(profesionales.OrderBy(o => o.Id).ToList());
        //}
        // GET: Profesional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.getProfesional(id);

            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // GET: Profesional/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,FechaNacimiento,Matricula,Foto,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                
                db.saveProfesional(profesional);
                return RedirectToAction("Index");
            }

            return View(profesional);
        }

        // GET: Profesional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.getProfesional(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // POST: Profesional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,FechaNacimiento,Matricula,Foto,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                db.updateProfesional(profesional);
                return RedirectToAction("Index");
            }
            return View(profesional);
        }

        // GET: Profesional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.getProfesional(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // POST: Profesional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.deleteProfesional(id);            
            return RedirectToAction("Index");
        }

        public JsonResult GetNombres(string Areas, string term = "")
        {
            var lista = db.getProfesionales().Where(o => o.Nombre.Contains(term)).OrderBy(o => o.Id).ToList();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        
    }
}
