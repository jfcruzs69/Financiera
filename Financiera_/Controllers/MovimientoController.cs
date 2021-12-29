using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Financiera_.Components.Page;
using Financiera_.Models;
using Financiera_.Models.DB;

namespace Financiera_.Controllers
{
    public class MovimientoController : Controller
    {
        // GET: MovimientoController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            ViewBag.idCuenta = id;
            
                
                
                
                List<movimiento> lst = new List<movimiento>();
                using (var db = new Models.DB.FinancieraContext())
                {
                    lst = (from c in db.Movimientos
                           select new movimiento
                           {
                               id = c.IdMovimiento,
                               idCuenta = c.IdCuenta,
                               idTipoMovimiento = c.IdTipoMovimiento,
                               referencia = c.Referencia,                               
                               importe = c.Importe,
                               cargo = c.Cargo,
                               abono = c.Abono,
                               fechaMovimiento = c.FechaMovimiento

                           }).ToList();

                    return View(lst);
                    //return View();
                }
            
        }

        // GET: MovimientoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovimientoController/Create
        public ActionResult Create()
            {
            ViewBag.tipoMovimiento = selectionList.lstTipoMovimiento(null);

            return View();
        }
        [HttpGet]
        public ActionResult Create(int idCta)
        {
            ViewBag.tipoMovimiento = selectionList.lstTipoMovimiento(null);
            ViewBag.idCuenta = idCta;

            return View();
        }

        // POST: MovimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                using (var db = new Models.DB.FinancieraContext())
                {
                    tipoMovimiento tMov = new tipoMovimiento();
                    tMov.GetTipoMovData(int.Parse(collection["tipoMovimiento"]));
                    cuenta cta = new cuenta();
                    cta.GetCuentaData(int.Parse(collection["IdCuenta"]));

                    var Mov = new Movimiento()
                    {

                        IdTipoMovimiento = int.Parse(collection["tipoMovimiento"]),
                        IdCuenta = int.Parse(collection["IdCuenta"]),
                        Referencia = collection["Referencia"].ToString(),
                        FechaMovimiento = DateTime.Parse(collection["FechaMovimiento"]),
                        FechaAlta = DateTime.Parse(collection["FechaMovimiento"]),
                        Importe = int.Parse(collection["Importe"]),
                        Cargo = tMov.signo == "+" ? 0 : int.Parse(collection["Importe"]),
                        Abono = tMov.signo == "-" ? 0 : int.Parse(collection["Importe"]),
                        IdUsuarioAlta = int.Parse(collection["IdUsuarioAlta"])


                    };

                    var x = db.Add(Mov);
                    var y = db.SaveChanges();

                    var Cta = db.Cuenta.Where(c => c.IdCuenta == cta.id).First(); ;
                    Cta.Saldo = tMov.signo == "+" ? Cta.Saldo + Mov.Importe : Cta.Saldo - Mov.Importe;

                    db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovimientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovimientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
