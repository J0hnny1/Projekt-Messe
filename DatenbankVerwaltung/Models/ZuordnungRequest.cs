namespace WebApplication1.Models;

public class ZuordnungRequest
{
    public int KundenID { get; set; }
    public List<int> ProduktgruppeIDs { get; set; }
}