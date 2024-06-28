using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tienda.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? oCliente { get; set; }

    [JsonIgnore]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
