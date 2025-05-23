var builder = WebApplication.CreateBuilder(args);

// Servisleri uygulama konteynerine ekleme
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP istek hattını yapılandırma
if (!app.Environment.IsDevelopment())
{
    // Hata sayfası yönlendirmesi (Geliştirme ortamı dışında)
    app.UseExceptionHandler("/Home/Error");

    // HSTS (HTTP Strict Transport Security) kullanımı
    // Varsayılan HSTS süresi 30 gündür. Üretim ortamında bu değeri değiştirebilirsiniz.
    app.UseHsts();
}

// HTTPS yönlendirmesi
app.UseHttpsRedirection();

// Statik dosyaları sunma
app.UseStaticFiles();

// Yönlendirme mekanizmasını etkinleştirme
app.UseRouting();

// Yetkilendirme mekanizmasını etkinleştirme
app.UseAuthorization();

// Varsayılan rota yapılandırması
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Events}/{action=List}/{id?}");

// Uygulamayı çalıştırma
app.Run();

