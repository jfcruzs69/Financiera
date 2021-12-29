using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financiera_.Models.DB;
using Financiera_.Models;
namespace Financiera_.Models
{
    public class cliente
    {
        public int id { get; set; }
        public string clave { get; set; }
        public string nombre  { get; set; }
        public string apPaterno { get; set; }
        public  string apMaterno { get; set; }
        public string apellidos { get; set; }
        public string rfc { get; set; }
        public int idEstatus  { get; set; }
        public string estatus { get; set; }
        public string tipoPersona { get; set; }
        public int idTipoIdentificacion { get; set; }
        public string tipoIdentificacion { get; set; }
        public string numeroIdentificacion { get; set; }

        public void GetClienteData(string clave)
        {
            //List<cliente> lstCliente = null;
            
            using (var db = new Models.DB.FinancieraContext())
            {
                var cte = db.Clientes.Where(c => c.Clave == clave);
                if (cte.Any()) {
                    //select new cliente
                    //{
                    this.id = cte.First().IdCliente;
                    this.clave = cte.First().Clave;
                    this.nombre = $"{cte.First().NombreRazonSocial} {cte.First().ApellidoPaterno} {cte.First().ApellidoMaterno}";
                    this.rfc = cte.First().Rfc;
                    this.idEstatus = cte.First().IdEstatus;
                                  
                              //};
                }

                
            }
        }

        public static string GetCteClave(int IdCliente)
        {

            using (var db = new Models.DB.FinancieraContext())
            {
                var cte = db.Clientes.Where(c => c.IdCliente == IdCliente);
                if (cte.Any())
                {
                    return cte.First().Clave;
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
