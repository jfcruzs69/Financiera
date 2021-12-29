using Financiera_.Components.Page;
using Financiera_.Models;
using Financiera_.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financiera_.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        public ActionResult Index()
        {
            
            
            List<cliente> lst = new List<cliente>();
            using (var db = new Models.DB.FinancieraContext())
            {
                lst = (from c in db.Clientes
                       select new cliente
                       {
                           id = c.IdCliente,
                           clave = c.Clave,
                           nombre = c.NombreRazonSocial,
                           apellidos = $"{c.ApellidoPaterno} {c.ApellidoMaterno}",
                           rfc = c.Rfc,
                           idEstatus = c.IdEstatus,
                           estatus = estatus.GetStatusDesc(c.IdEstatus),
                           tipoPersona = c.TipoPersona == "PF" ? "Persona física" : "Persona Moral",
                           idTipoIdentificacion = c.IdTipoIdentificacion,
                           tipoIdentificacion = tipoIdentificacion.GetDescTipoIdentificacion(c.IdTipoIdentificacion),
                           numeroIdentificacion = c.NumeroIdentificacion
            }).ToList();
            }
            
            //ViewBag.tipoMov = selectionList.lstTipoMovimiento(2);

            return View(lst);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            ViewBag.estatus = selectionList.lstStatus(0);
            ViewBag.tipoPersona = selectionList.lstTipoPersona(null);
            ViewBag.tipoIdentificacion = selectionList.lstTipoIdentificacion(null);

            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection )
        {
            try
            {
                //Cliente Cte = new();
                using (var db = new Models.DB.FinancieraContext())
                {
                    var Cte = new Cliente()
                    {

                        Clave = collection["Clave"].ToString(),
                        NombreRazonSocial = collection["NombreRazonSocial"].ToString(),
                        ApellidoPaterno = collection["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = collection["ApellidoMaterno"].ToString(),
                        Rfc=collection["Rfc"].ToString(),
                        
                        IdEstatus = int.Parse( collection["IdEstatus"]),
                        FechaAlta = DateTime.Parse(collection["FechaAlta"]),
                        IdUsuarioAlta = 1,
                        TipoPersona = int.Parse(collection["TipoPersona"]) == 1?"PF":"PM",
                        IdTipoIdentificacion = int.Parse(collection["IdTipoIdentificacion"]),
                        NumeroIdentificacion = collection["NumeroIdentificacion"].ToString(),

                    };

                  var x =  db.Add(Cte);
                  var y=  db.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
