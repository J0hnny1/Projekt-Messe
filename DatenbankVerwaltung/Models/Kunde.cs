using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace WebApplication1.Models;

public class Kunde
{


    [Key]
    public int Id { get; set; }
    public String? Name { get; set; }
    public String? Vorname { get; set; }
    public DateTime? Geburtstag { get; set; }
    public string? PLZ { get; set; }
    public string? Stadt { get; set; }
    public string? Straße { get; set; }
    public bool? Firmenberater { get; set; }
    public Firma? Firma { get; set; }
    public byte[]? Bild { get; set; }
}