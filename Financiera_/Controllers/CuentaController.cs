using Financiera_.Models;
using Financiera_.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financiera_.Components.Page;

namespace Financiera_.Controllers
{
    public class CuentaController : Controller
    {


        public IActionResult Index()
        {
            estatus st = new estatus();
            ViewBag.tipoFiltro = selectionList.lstFiltroCta(1);
            List<cuenta> lst = new List<cuenta>();
            using (var db = new Models.DB.FinancieraContext())
            {
                lst = (from c in db.Cuenta
                       select new cuenta
                       {
                           id = c.IdCuenta,
                           numero = c.Numero,
                           idCliente = c.IdCliente,
                           claveCliente = cliente.GetCteClave(c.IdCliente), //cliente.GetClienteData(c.IdCliente).First().clave,
                           idTipoCuenta = c.IdTipoCuenta,
                           saldo = c.Saldo,
                           tipoCuenta = tipoCuenta.GetTipoCtaDesc(c.IdTipoCuenta),
                           idEstatus = c.IdEstatus,
                           estatus = estatus.GetStatusDesc(c.IdEstatus),
                           fechaAlta = c.FechaAlta

                       }).ToList();
            }


            return View(lst);
            //return View();
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            estatus st = new estatus();
            ViewBag.tipoFiltro = selectionList.lstFiltroCta(2);
            ViewBag.ClaveCte = cliente.GetCteClave(id);
            List<cuenta> lst = new List<cuenta>();
            using (var db = new Models.DB.FinancieraContext())
            {
                lst = (from c in db.Cuenta
                       select new cuenta
                       {
                           id = c.IdCuenta,
                           numero = c.Numero,
                           idCliente = c.IdCliente,
                           claveCliente = cliente.GetCteClave(c.IdCliente), //cliente.GetClienteData(c.IdCliente).First().clave,
                           idTipoCuenta = c.IdTipoCuenta,
                           tipoCuenta = tipoCuenta.GetTipoCtaDesc(c.IdTipoCuenta),
                           saldo = c.Saldo,
                           idEstatus = c.IdEstatus,
                           estatus = estatus.GetStatusDesc(c.IdEstatus),
                           fechaAlta = c.FechaAlta

                       }).ToList();

                var x = lst.Where(l => l.claveCliente == cliente.GetCteClave(id));

                return View(x);
                //return View();
            }
            }

        [HttpPost]
        public IActionResult Index(int? tipoFiltro, string Criterio)
        {
            ViewBag.tipoFiltro = selectionList.lstFiltroCta(tipoFiltro);
            estatus st = new estatus();
            List<cuenta> lst = new List<cuenta>();
            using (var db = new Models.DB.FinancieraContext())
            {
                if(tipoFiltro == 1) {
                    lst = (from c in db.Cuenta 
                           select new cuenta
                           {
                               id = c.IdCuenta,
                               numero = c.Numero,
                               idCliente = c.IdCliente,
                               claveCliente = cliente.GetCteClave(c.IdCliente), //cliente.GetClienteData(c.IdCliente).First().clave,
                               idTipoCuenta = c.IdTipoCuenta,
                               tipoCuenta = tipoCuenta.GetTipoCtaDesc(c.IdTipoCuenta),
                               saldo = c.Saldo,
                               idEstatus = c.IdEstatus,
                               estatus = estatus.GetStatusDesc(c.IdEstatus),
                               fechaAlta = c.FechaAlta

                           }).ToList();

                    var x = lst.Where(l => l.numero == Criterio);
                    //lst = x;
                    return View(x);
                } else {
                    lst = (from c in db.Cuenta
                           select new cuenta
                           {
                               id = c.IdCuenta,
                               numero = c.Numero,
                               idCliente = c.IdCliente,
                               claveCliente = cliente.GetCteClave(c.IdCliente), //cliente.GetClienteData(c.IdCliente).First().clave,
                               idTipoCuenta = c.IdTipoCuenta,
                               tipoCuenta = tipoCuenta.GetTipoCtaDesc(c.IdTipoCuenta),
                               saldo = c.Saldo,
                               idEstatus = c.IdEstatus,
                               estatus = estatus.GetStatusDesc(c.IdEstatus),
                               fechaAlta = c.FechaAlta

                           }).ToList();

                    var x = lst.Where(l => l.claveCliente == Criterio);
                    
                    return View(x); }
                

            }
            //return View();
        }

        public ActionResult Create()
        {
            ViewBag.estatus = selectionList.lstStatus(1);
            ViewBag.tipoCuenta = selectionList.lstTipocuenta(0);

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( string Cliente,string Numero, int IdTipoCuenta,double Saldo, int IdEstatus, string FechaAlta, int IdUsuarioAlta)
        {
            ViewBag.estatus = selectionList.lstStatus(1);
            ViewBag.tipoCuenta = selectionList.lstTipocuenta(0);

            //Se recupera info del cliente
            cliente cte = new cliente();
            cte.GetClienteData(Cliente);

            try
            {
                //Cliente Cte = new();
                using (var db = new Models.DB.FinancieraContext())
                {
                    var Cta = new  Cuentum()
                    {
                        IdCliente = cte.id,
                        Numero = Numero,
                        IdTipoCuenta = IdTipoCuenta,
                        IdEstatus = IdEstatus,
                        Saldo = decimal.Parse(Saldo.ToString()),
                        FechaAlta = DateTime.Parse(FechaAlta),
                        IdUsuarioAlta = 1
                    };

                    var x = db.Add(Cta);
                    var y = db.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                return View();
            }



            //return View();
        }
    }
}
