using Ecommerce.Infrastructure.Data.Configurations;
using Ecommerce.Web;
using Ecommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// đăng ký service
builder.Services.AddControllersWithViews();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddWebServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
