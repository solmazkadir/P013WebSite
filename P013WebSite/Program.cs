using P013WebSite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); //burada veritaban� i�lemleri i�in kulland���m�z context tan�t�yoruz
//veritaban� olu�turmak i�in �st men�den tools> options> nuget package manager  > package manager console men�s�nden komut yazma ekran�n� a��yoruz
//bu erkana(pm nin yan�na) add-migration InitialCreate yaz�p enter a bas�yoruz
//Migrations klas�r� ve initialcreate class� olu�turduktan sonra update-database yaz�p enter a bas�yoruz
//done mesaj� geldiyse i�lem ba�ar�l�d�r

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

app.MapControllerRoute( //name=admin, controller=main olarak de�i�tirildi
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
