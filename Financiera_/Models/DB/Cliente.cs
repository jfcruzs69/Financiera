using System;
using System.Collections.Generic;

#nullable disable

namespace Financiera_.Models.DB
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteDireccions = new HashSet<ClienteDireccion>();
            Cuenta = new HashSet<Cuentum>();
        }

        public int IdCliente { get; set; }
        public string Clave { get; set; }
        public string NombreRazonSocial { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Rfc { get; set; }
        public int IdEstatus { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int IdUsuarioAlta { get; set; }
        public string TipoPersona { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }

        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual Usuario IdUsuarioAltaNavigation { get; set; }
        //public virtual TipoIdentificacion IdTipoIdentificacionNavigation { get; set; }
        public virtual ICollection<ClienteDireccion> ClienteDireccions { get; set; }
        public virtual ICollection<Cuentum> Cuenta { get; set; }
        
    }
}
