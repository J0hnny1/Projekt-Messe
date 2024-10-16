using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<Context>());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

ServerContext context = new ServerContext();

app.MapGet("customer", async Task<Kunde> (int id) =>
    {
        var kunde = await context.Kunden.Include(k => k.Firma).Include(k => k.Firma)
            .FirstOrDefaultAsync(k => k.Id == id);

        if (kunde == null)
        {
            new HttpRequestException();
        }

        return kunde;
    })
    .WithOpenApi();

app.MapPost("customer",
    (Kunde customer) =>
    {
        Firma firma = customer.Firma;

        Firma firmaE = context.Firma.FirstOrDefault(f => f.FirmaID == firma.FirmaID);
        if (firmaE == null)
        {
            context.Firma.Add(new Firma
                { Name = firma.Name, PLZ = firma.PLZ, Stadt = firma.Stadt, Straße = firma.Straße });
            context.SaveChanges();
        }
        else
        {
            firma = firmaE;
        }

        context.Kunden.Add(new Kunde
        {
            Name = customer.Name, Vorname = customer.Vorname, Geburtstag = customer.Geburtstag, PLZ = customer.PLZ,
            Stadt = customer.Stadt, Straße = customer.Straße, Firmenberater = customer.Firmenberater,
            Firma = firma, Bild = customer.Bild
        });
        //context.Firma.Add(new Firma{FirmaID = 1, Name = "Firma1", Stadt = "Stadt1", PLZ = "12345", Straße = "Straße1"});
        context.SaveChanges();
    }).WithOpenApi();
app.MapPost("zuordnung",
    (ZuordnungRequest request) =>
    {
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 1, Name = "Medien und Unterhaltung" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 2, Name = "Bekleidung und Mode" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 3, Name = "Haushalt" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 4, Name = "Möbel und Einrichtung" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 5, Name = "Lebensmittelwaren" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 6, Name = "Hygiene und Kosmetik" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 7, Name = "Sport- und Freizeitartikel" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 8, Name = "Büro und Schreibwaren" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 9, Name = "Bau- und Heimwerk" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 10, Name = "Autozubehör" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 11, Name = "Wellnessprodukte" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 12, Name = "Bücher, Musik und Filme" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 13, Name = "Schmuck und Uhren" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 14, Name = "Baby- und Kinderprodukte" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 15, Name = "Reisebedarf" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 16, Name = "Haustierbedarf" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 17, Name = "Softwareprodukte" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 18, Name = "Dienstleistungen für Schönheitsbehandlungen" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 19, Name = "Industrie- und Gewerbebedarf" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 20, Name = "Veranstaltungs- und Partybedarf" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 21, Name = "Energie und Umwelt" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 22, Name = "Bildung und Lernmaterialien" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 23, Name = "Kunst und Bastelbedarf" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 24, Name = "Sicherheits- und Überwachungsausrüstung" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 25, Name = "Musik- und Tontechnik" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 26, Name = "Spielzeuge" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 27, Name = "Souvenir und Geschenkartikel" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 28, Name = "Fotografie- und Videografie" });
        context.Produktgruppe.Add( new Produktgruppe { ProduktgruppenID = 29, Name = "Garten- und Landschaftsbedarf" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 30, Name = "Transport und Logistik" });
        var kunde = context.Kunden.Find(request.KundenID);
        if (kunde == null)
        {
            return Results.NotFound("Kunde not found");
        }

        foreach (var produktgruppeId in request.ProduktgruppeIDs)
        {
            var produktgruppe = context.Produktgruppe.Find(produktgruppeId);
            if (produktgruppe == null)
            {
                return Results.NotFound($"Produktgruppe with ID {produktgruppeId} not found");
            }

            var match = new MatchKundeProduktgruppe
            {
                Kunde = kunde,
                Produktgruppe = produktgruppe
            };

            context.MatchKundeProduktgruppe.Add(match);
        }

        context.SaveChanges();
        return Results.Ok("Zuordnung successfully created");
    }).WithOpenApi();

app.Run();