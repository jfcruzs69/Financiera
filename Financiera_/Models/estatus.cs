using Financiera_.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financiera_.Models
{

    public class estatus
    {
        public int id { get; set; }
        public string clave { get; set; }
        public string descripcion { get; set; }


        public static string GetStatusDesc(int IdEstatus)
        {

            using (var db = new Models.DB.FinancieraContext())
            {
                var estatus = db.Estatuses.Where(e => e.IdEstatus == IdEstatus);
                if (estatus.Any())
                {
                    return estatus.First().Descripcion;
                }
                else
                {
                    return "";
                }

                //var estatus = db.Estatuses.Where(e => e.IdEstatus == c.IdEstatus);
                //return "";
            }
        }
    }
}
