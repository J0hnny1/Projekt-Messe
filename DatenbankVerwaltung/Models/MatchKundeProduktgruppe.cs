namespace WebApplication1.Models;

public class MatchKundeProduktgruppe
{
    public int Id { get; set; }
    public Kunde Kunde { get; set; }
    public Produktgruppe Produktgruppe { get; set; }
}