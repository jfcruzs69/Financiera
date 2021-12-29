using System;
using System.Collections.Generic;

#nullable disable

namespace Financiera_.Models.DB
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCuenta { get; set; }
        public int IdEstatus { get; set; }
        public string Numero { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdUsuarioAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual TipoCuentum IdTipoCuentaNavigation { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
