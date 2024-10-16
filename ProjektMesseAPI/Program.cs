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

        firma = context.Firma.FirstOrDefault(f => f.FirmaID == firma.FirmaID);
        if (firma == null)
        {
            context.Firma.Add(new Firma{Name = firma.Name, PLZ = firma.PLZ, Stadt = firma.Stadt, Straße = firma.Straße});
            context.SaveChanges();
        }

        context.Kunden.Add(new Kunde
        {
            Name = customer.Name, Vorname = customer.Vorname, Geburtstag = customer.Geburtstag, PLZ = customer.PLZ,
            Stadt = customer.Stadt, Straße = customer.Straße, Firmenberater = customer.Firmenberater,
            Firma = firma, Bild = customer.Bild, Produktgruppen = customer.Produktgruppen
        });
        //context.Firma.Add(new Firma{FirmaID = 1, Name = "Firma1", Stadt = "Stadt1", PLZ = "12345", Straße = "Straße1"});
        context.SaveChanges();
    }).WithOpenApi();


app.Run();