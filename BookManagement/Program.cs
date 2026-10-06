using BookManagement.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Thêm MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Xử lý lỗi khi chạy Production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTPS
app.UseHttpsRedirection();

// Static files
app.UseStaticFiles();

// Routing
app.UseRouting();

// Authorization
app.UseAuthorization();

// ================================
// REQUEST LOGGING MIDDLEWARE
// ================================
app.UseMiddleware<RequestLoggingMiddleware>();

// ================================
// ROUTING CONTROLLER
// ================================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();