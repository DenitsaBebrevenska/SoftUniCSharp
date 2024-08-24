using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//will continue using the environment variables for now later will switch to secrets.json
string connectionString =
	Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User)
	?? throw new InvalidOperationException("ConnectionString environment variable is not set."); ;
builder.Services.AddDbContext<ShoppingListContext>(options =>
	options.UseSqlServer(connectionString));

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
