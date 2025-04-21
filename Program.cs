var builder = WebApplication.CreateBuilder(args);

// Servisleri uygulama konteynerine ekleme
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP istek hattýný yapýlandýrma
if (!app.Environment.IsDevelopment())
{
    // Hata sayfasý yönlendirmesi (Geliþtirme ortamý dýþýnda)
    app.UseExceptionHandler("/Home/Error");

    // HSTS (HTTP Strict Transport Security) kullanýmý
    // Varsayýlan HSTS süresi 30 gündür. Üretim ortamýnda bu deðeri deðiþtirebilirsiniz.
    app.UseHsts();
}

// HTTPS yönlendirmesi
app.UseHttpsRedirection();

// Statik dosyalarý sunma
app.UseStaticFiles();

// Yönlendirme mekanizmasýný etkinleþtirme
app.UseRouting();

// Yetkilendirme mekanizmasýný etkinleþtirme
app.UseAuthorization();

// Varsayýlan rota yapýlandýrmasý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Events}/{action=List}/{id?}");

// Uygulamayý çalýþtýrma
app.Run();

