using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tienda.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdProveedor { get; set; }
    public virtual Categoria? oCategoria { get; set; }

    public virtual Proveedores? oProveedores { get; set; }

    [JsonIgnore]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
