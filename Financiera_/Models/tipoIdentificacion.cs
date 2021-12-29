using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financiera_.Models
{
    public class tipoIdentificacion
    {
        public int id { get; set; }
        public string clave { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaAlta { get; set; }
        public int idUsuarioAlta { get; set; }
        public int idEstatus { get; set; }
        public string estatus { get; set; }

        public static string GetDescTipoIdentificacion(int idTipoIdentificacion)
        {
            using (var db = new Models.DB.FinancieraContext())
            {
                var tipoIdentificacion = db.TipoIdentificacions.Where(m => m.IdTipoIdentificacion == idTipoIdentificacion);
                if (tipoIdentificacion.Any())
                {
                    return tipoIdentificacion.First().Descripcion;
                }
                else
                {
                    return "";
                }

            }
        }
    }

}

