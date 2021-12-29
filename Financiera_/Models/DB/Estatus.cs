using System;
using System.Collections.Generic;

#nullable disable

namespace Financiera_.Models.DB
{
    public partial class Estatus
    {
        public Estatus()
        {
            ClienteDireccions = new HashSet<ClienteDireccion>();
            Clientes = new HashSet<Cliente>();
            Cuenta = new HashSet<Cuentum>();
            Direccions = new HashSet<Direccion>();
            TipoMovimientos = new HashSet<TipoMovimiento>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdEstatus { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int? IdUsuarioAlta { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Usuario IdUsuarioAltaNavigation { get; set; }
        public virtual ICollection<ClienteDireccion> ClienteDireccions { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Cuentum> Cuenta { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
        public virtual ICollection<TipoMovimiento> TipoMovimientos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
