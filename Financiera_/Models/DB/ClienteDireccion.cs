using System;
using System.Collections.Generic;

#nullable disable

namespace Financiera_.Models.DB
{
    public partial class ClienteDireccion
    {
        public int IdCliente { get; set; }
        public int IdDireccion { get; set; }
        public int IdEstatus { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int IdUsuarioAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Direccion IdDireccionNavigation { get; set; }
        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual Usuario IdUsuarioAltaNavigation { get; set; }
    }
}
