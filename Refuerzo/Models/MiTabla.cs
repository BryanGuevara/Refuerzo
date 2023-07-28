using System;
using System.Collections.Generic;

namespace Refuerzo.Models;

public partial class MiTabla
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public string? CorreoElectronico { get; set; }
}
