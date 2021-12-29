﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Financiera_.Models.DB
{
    public partial class ClienteIdentificacion
    {
        public int IdCliente { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public int IdEstatus { get; set; }
        public int IdUsuarioAlta { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual TipoIdentificacion IdTipoIdentificacionNavigation { get; set; }
        public virtual Usuario IdUsuarioAltaNavigation { get; set; }
    }
}
