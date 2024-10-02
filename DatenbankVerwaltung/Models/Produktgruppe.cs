using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Produktgruppe
{
    [Key]
    public int ProduktgruppenID { get; set; }
    public string Name { get; set; }
}