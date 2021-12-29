using System;
using System.Collections.Generic;

#nullable disable

namespace Financiera_.Models.DB
{
    public partial class Usuario
    {
        public Usuario()
        {
            ClienteDireccions = new HashSet<ClienteDireccion>();
            Clientes = new HashSet<Cliente>();
            Estatuses = new HashSet<Estatus>();
            TipoCuenta = new HashSet<TipoCuentum>();
            TipoDireccions = new HashSet<TipoDireccion>();
            TipoMovimientos = new HashSet<TipoMovimiento>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string ClaveAcceso { get; set; }
        public string Contrasenia { get; set; }
        public int IdEstatus { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual ICollection<ClienteDireccion> ClienteDireccions { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Estatus> Estatuses { get; set; }
        public virtual ICollection<TipoCuentum> TipoCuenta { get; set; }
        public virtual ICollection<TipoDireccion> TipoDireccions { get; set; }
        public virtual ICollection<TipoMovimiento> TipoMovimientos { get; set; }
    }
}
