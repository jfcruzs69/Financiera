using System;
using System.Collections.Generic;

#nullable disable

namespace Financiera_.Models.DB
{
    public partial class Direccion
    {
        public Direccion()
        {
            ClienteDireccions = new HashSet<ClienteDireccion>();
        }

        public int IdDireccion { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public string CodigoPostal { get; set; }
        public string Alcaldia { get; set; }
        public string Colonia { get; set; }
        public string Ciudad { get; set; }
        public int IdTipoDireccion { get; set; }
        public int IdUsuarioAlta { get; set; }
        public int IdEstatus { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual TipoDireccion IdTipoDireccionNavigation { get; set; }
        public virtual ICollection<ClienteDireccion> ClienteDireccions { get; set; }
    }
}
