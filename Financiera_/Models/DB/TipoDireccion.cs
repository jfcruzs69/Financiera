using System;
using System.Collections.Generic;

#nullable disable

namespace Financiera_.Models.DB
{
    public partial class TipoDireccion
    {
        public TipoDireccion()
        {
            Direccions = new HashSet<Direccion>();
        }

        public int IdTipoDireccion { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuarioAlta { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Usuario IdUsuarioAltaNavigation { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}
