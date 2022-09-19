using Microsoft.EntityFrameworkCore;
using WebApplicationPetsShop.Data;
using WebApplicationPetsShop.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddControllersWithViews();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<ShopContext>(options => options.UseSqlite(connectionString));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<ShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
