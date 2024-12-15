using System;
using System.Collections.Generic;

namespace ProjektMesse.Models;

public partial class Firma
{
    public int FirmaId { get; set; }

    public string Name { get; set; } = null!;

    public string Plz { get; set; } = null!;

    public string Stadt { get; set; } = null!;

    public string Straße { get; set; } = null!;

    public virtual ICollection<Kunden> Kundens { get; set; } = new List<Kunden>();
}
