using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tienda.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int? IdFactura { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public virtual Factura? oFactura { get; set; }

    public virtual Producto? oProducto { get; set; }
}
