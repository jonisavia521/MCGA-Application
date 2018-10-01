using AutoMapper;
using MCGA.Entities;
using MCGA.UI.Process;
using MCGA.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MCGA.WebSite.Controllers
{
    public class AfiliadoController : Controller
    {
        AfiliadoController()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<List<Afiliado>, List<AfiliadoVM>>();
                cfg.CreateMap<Afiliado, AfiliadoVM>();
            });
        }
        private AfiliadoProcess db = new AfiliadoProcess();

        // GET: Afiliado
        public ActionResult Index()
        {
            List<Afiliado> afiliadoes = db.getAfiliados();
            List<AfiliadoVM> afiliadoVM = Mapper.Map<List<AfiliadoVM>>(afiliadoes);
            return View(afiliadoVM);
        }

        // GET: Afiliado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.getAfiliado(id);

            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<AfiliadoVM>(afiliado));
        }

        // GET: Afiliado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Afiliado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,TipoSexoId,FechaNacimiento,EstadoCivilId,NumeroAfiliado,PlanId,Foto,Habilitado,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {

                db.saveAfiliado(Mapper.Map<Afiliado>(afiliado));
                return RedirectToAction("Index");
            }

            return View(afiliado);
        }

        // GET: Afiliado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.getAfiliado(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<AfiliadoVM>(afiliado));
        }

        // POST: Afiliado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,TipoSexoId,FechaNacimiento,EstadoCivilId,NumeroAfiliado,PlanId,Foto,Habilitado,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                db.updateAfiliado(Mapper.Map<Afiliado>(afiliado));
                return RedirectToAction("Index");
            }
            return View(afiliado);
        }

        // GET: Afiliado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.getAfiliado(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<AfiliadoVM>(afiliado));
        }

        // POST: Afiliado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.deleteAfiliado(id);
            return RedirectToAction("Index");
        }

       
    }
}
