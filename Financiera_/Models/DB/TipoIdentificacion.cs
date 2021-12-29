
using System;
using System.Collections.Generic;

#nullable disable

namespace Financiera_.Models.DB
{
    public partial class TipoIdentificacion
    {
        //public TipoIdentificacion()
        //{
        //    Clientes = new HashSet<Cliente>();
        //}
        public int IdTipoIdentificacion { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int IdEstatus { get; set; }
        public int IdUsuarioAlta { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        //public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
