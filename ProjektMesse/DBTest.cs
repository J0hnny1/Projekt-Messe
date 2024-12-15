using ProjektMesse.Models;

namespace ProjektMesse;

public class DBTest
{
    DatabseContext db = new DatabseContext();
    public void Test()
    {
        db.Database.EnsureCreated();
        db.Produktgruppe.Add( new Produktgruppe { ProduktgruppenId = 1, Name = "Medien und Unterhaltung" });  
        db.SaveChanges();
        var node = db.Produktgruppe.GetAsyncEnumerator();
        while (node.MoveNextAsync().Result)
        {
            Console.WriteLine(node.Current.Name);
        }
    }
}