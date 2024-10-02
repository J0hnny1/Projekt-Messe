namespace WebApplication1.Models;

public class CustomerDTO
{
 
    public String Name { get; set; }
    public String Vorname { get; set; }
    public DateOnly Geburtstag { get; set; }
    public string PLZ { get; set; }
    public string Stadt { get; set; }
    public string Straße { get; set; }
    public bool Firmenberater { get; set; }
    public int FirmaID { get; set; }
    public byte[] Bild { get; set; }
    public List<int> Produktgruppen { get; set; }
}