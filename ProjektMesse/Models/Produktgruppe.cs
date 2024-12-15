using System;
using System.Collections.Generic;

namespace ProjektMesse.Models;

public partial class Produktgruppe
{
    public int ProduktgruppenId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MatchKundeProduktgruppe> MatchKundeProduktgruppes { get; set; } = new List<MatchKundeProduktgruppe>();
}
