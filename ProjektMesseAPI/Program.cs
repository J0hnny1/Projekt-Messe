using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
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

app.MapPost("customer",
    (List<Kunde> customerList) =>
    {
        foreach (var customer in customerList)
        {
            try
            {
                var kunde = context.Kunden.FirstOrDefault(t => t.Id == customer.Id);
                if (kunde == null)
                {
                    Console.WriteLine(customer.Name + " " + customer.Id);
                    context.Kunden.Add(customer);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Customer failed");
                Console.WriteLine(e);
            }
        }

        context.SaveChanges();
    }).WithOpenApi();

app.MapPost("firma",
    (List<Firma> firmaList) =>
    {
        foreach (var firma in firmaList)
        {
            try
            {
                var _firma = context.Firma.FirstOrDefault(t => t.FirmaID == firma.FirmaID);
                if (_firma == null)
                {
                    context.Firma.Add(firma);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Firma failed");
                Console.WriteLine(e);
            }
        }

        context.SaveChanges();
        return Results.Ok("Firma successfully created");
    }).WithOpenApi();

app.MapPost("zuordnung",
    (List<MatchKundeProduktgruppe> requestList) =>
    {
        foreach (var request in requestList)
        {
            try
            {
                Console.WriteLine("Zuordnung" + request.Id + ", " + request.KundeId + ", " + request.ProduktgruppeId);
                var _request = context.MatchKundeProduktgruppe.FirstOrDefault(t => t.Id == request.Id);
                if (_request == null)
                {
                    context.MatchKundeProduktgruppe.Add(new MatchKundeProduktgruppe
                        { ProduktgruppeId = request.ProduktgruppeId, KundeId = request.KundeId, Id = request.Id });
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Zuordnung failed");
                Console.WriteLine(e);
            }
        }

        return Results.Ok("Zuordnung successfully created");
    }).WithOpenApi();

app.MapPost("initProductGroups",
    () =>
    {
        context.Kunden.Add(new Kunde { Name = "test", Id = 2 });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 1, Name = "Medien und Unterhaltung" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 2, Name = "Bekleidung und Mode" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 3, Name = "Haushalt" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 4, Name = "Möbel und Einrichtung" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 5, Name = "Lebensmittelwaren" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 6, Name = "Hygiene und Kosmetik" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 7, Name = "Sport- und Freizeitartikel" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 8, Name = "Büro und Schreibwaren" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 9, Name = "Bau- und Heimwerk" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 10, Name = "Autozubehör" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 11, Name = "Wellnessprodukte" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 12, Name = "Bücher, Musik und Filme" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 13, Name = "Schmuck und Uhren" });
        context.Produktgruppe.Add(
            new Produktgruppe { ProduktgruppenID = 14, Name = "Baby- und Kinderprodukte" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 15, Name = "Reisebedarf" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 16, Name = "Haustierbedarf" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 17, Name = "Softwareprodukte" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 18, Name = "Dienstleistungen für Schönheitsbehandlungen" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 19, Name = "Industrie- und Gewerbebedarf" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 20, Name = "Veranstaltungs- und Partybedarf" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 21, Name = "Energie und Umwelt" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 22, Name = "Bildung und Lernmaterialien" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 23, Name = "Kunst und Bastelbedarf" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 24, Name = "Sicherheits- und Überwachungsausrüstung" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 25, Name = "Musik- und Tontechnik" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 26, Name = "Spielzeuge" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 27, Name = "Souvenir und Geschenkartikel" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 28, Name = "Fotografie- und Videografie" });
        context.Produktgruppe.Add(new Produktgruppe
            { ProduktgruppenID = 29, Name = "Garten- und Landschaftsbedarf" });
        context.Produktgruppe.Add(new Produktgruppe { ProduktgruppenID = 30, Name = "Transport und Logistik" });
        context.SaveChanges();
    }).WithOpenApi();

app.Run();