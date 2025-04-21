var builder = WebApplication.CreateBuilder(args);

// Servisleri uygulama konteynerine ekleme
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP istek hatt�n� yap�land�rma
if (!app.Environment.IsDevelopment())
{
    // Hata sayfas� y�nlendirmesi (Geli�tirme ortam� d���nda)
    app.UseExceptionHandler("/Home/Error");

    // HSTS (HTTP Strict Transport Security) kullan�m�
    // Varsay�lan HSTS s�resi 30 g�nd�r. �retim ortam�nda bu de�eri de�i�tirebilirsiniz.
    app.UseHsts();
}

// HTTPS y�nlendirmesi
app.UseHttpsRedirection();

// Statik dosyalar� sunma
app.UseStaticFiles();

// Y�nlendirme mekanizmas�n� etkinle�tirme
app.UseRouting();

// Yetkilendirme mekanizmas�n� etkinle�tirme
app.UseAuthorization();

// Varsay�lan rota yap�land�rmas�
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Events}/{action=List}/{id?}");

// Uygulamay� �al��t�rma
app.Run();

