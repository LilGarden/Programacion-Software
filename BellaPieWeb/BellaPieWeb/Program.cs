using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using BellaPieWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUriAspNet"));
var secretClient = new SecretClient(keyVaultEndpoint, new DefaultAzureCredential());

KeyVaultSecret kvs = secretClient.GetSecret("ConnectionStrings--DefaultConnection");
builder.Services.AddDbContext<BellapiewebContext>(options =>
{
	options.UseSqlServer(kvs.Value);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// un servicio de tipo BellapiewebContext que se conecte a la base de datos azure /con la cadena de conexion que se encuentra en el vault



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
