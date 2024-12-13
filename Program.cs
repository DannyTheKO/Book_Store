using Book_Store.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connect to MySQL database
//builder.Services.AddDbContext<BookStoreV20Context>(options =>
//    options.UseMySQL(builder.Configuration.GetConnectionString("Default")!)
//    );

// Connect to SQL Server Database
builder.Services.AddDbContext<BookStoreV20Context>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default")!)
);

var app = builder.Build();

// Add this block to seed the database
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<BookStoreV20Context>();
	DbInitializer.Initialize(context);
}


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
