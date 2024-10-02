using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Firma
{
    [Key]
    public int FirmaID { get; set; }
    public string Name { get; set; }
    public string PLZ { get; set; }
    public string Stadt { get; set; }
    public string Straße { get; set; }
}