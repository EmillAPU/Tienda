using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tienda.Models;

public partial class Proveedores
{
    public int IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    [JsonIgnore]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
