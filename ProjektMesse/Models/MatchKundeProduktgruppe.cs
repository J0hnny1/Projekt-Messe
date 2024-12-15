using System;
using System.Collections.Generic;

namespace ProjektMesse.Models;

public partial class MatchKundeProduktgruppe
{
    public int Id { get; set; }

    public int KundeId { get; set; }

    public int ProduktgruppenId { get; set; }

    public virtual Kunden Kunde { get; set; } = null!;

    public virtual Produktgruppe Produktgruppen { get; set; } = null!;
}
