using System;
using System.Collections.Generic;

namespace ProjektMesse.Models;

public partial class Kunden
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Vorname { get; set; }

    public string? Geburtstag { get; set; }

    public string? Plz { get; set; }

    public string? Stadt { get; set; }

    public string? Straße { get; set; }

    public int? Firmenberater { get; set; }

    public int? FirmaId { get; set; }

    public byte[]? Bild { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual ICollection<MatchKundeProduktgruppe> MatchKundeProduktgruppes { get; set; } = new List<MatchKundeProduktgruppe>();
}
