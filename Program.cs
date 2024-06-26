using Microsoft.EntityFrameworkCore;

using WebAspNetPractica_26_06_2024;
using WebAspNetPractica_26_06_2024.DB;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapGet(
    "/ping", () => new { Massage = "pong", Time = DateTime.UtcNow });
app.MapGet(
    "/mount", async (ApplicationDbContext db) => await db.mountainPeaks.ToListAsync());
app.MapGet(
    "/mount/{id:int}", async (ApplicationDbContext db, int id) => await db.mountainPeaks.FirstAsync(r => r.id == id));

app.MapPost("/mount/add", async(MountainPeaks mount, ApplicationDbContext db) =>
{
    db.Add(mount);
    await db.SaveChangesAsync();
    return mount;
});

app.MapDelete("mount/{id:int}", async (int id, ApplicationDbContext db) =>
{
    MountainPeaks delete = await db.mountainPeaks.FirstOrDefaultAsync(r => r.id == id);
    if(delete != null)
    {
        db.Remove(delete);
        await db.SaveChangesAsync();
    }
});

app.MapPost("/mount/{id:int}", async (int id, MountainPeaks mount, ApplicationDbContext db) =>
{
    MountainPeaks update = await db.mountainPeaks.FirstOrDefaultAsync(p => p.id == id); 
    if (update != null)
    {
        update.mountainHeight = mount.mountainHeight;
        update.mountainName = mount.mountainName;
        update.countryName = mount.countryName;
        update.mountainSystem = mount.mountainSystem;
        await db.SaveChangesAsync();
    }
});
app.Run();
