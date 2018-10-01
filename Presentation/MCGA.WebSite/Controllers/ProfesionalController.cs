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
using MCGA.WebSite.Models;
namespace MCGA.WebSite.Controllers
{
    public class ProfesionalController : Controller
    {
        ProfesionalController()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<List<Profesional>, List<ProfesionalVM>>();
                cfg.CreateMap<Profesional, ProfesionalVM>();
            });
        }
        private ProfesionalProcess db = new ProfesionalProcess();
        
        // GET: Profesional
        public ActionResult Index()
        {
            
            List<Profesional> profesionales = db.getProfesionales();
            List<ProfesionalVM> profesionalVM = Mapper.Map<List<ProfesionalVM>>(profesionales);
            return View(profesionalVM);
        }

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
            return View(Mapper.Map<ProfesionalVM>(profesional));
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
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,FechaNacimiento,Matricula,Foto,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] ProfesionalVM profesional)
        {
            if (ModelState.IsValid)
            {
                
                db.saveProfesional(Mapper.Map<Profesional>(profesional));
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
            return View(Mapper.Map<ProfesionalVM>(profesional));
        }

        // POST: Profesional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,FechaNacimiento,Matricula,Foto,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] ProfesionalVM profesional)
        {
            if (ModelState.IsValid)
            {
                db.updateProfesional(Mapper.Map<Profesional>(profesional));
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
            return View(Mapper.Map<ProfesionalVM>(profesional));
        }

        // POST: Profesional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.deleteProfesional(id);            
            return RedirectToAction("Index");
        }

        
    }
}
