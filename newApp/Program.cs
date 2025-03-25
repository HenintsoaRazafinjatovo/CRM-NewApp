using newApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<LoginService>(); // A
builder.Services.AddAuthentication("Cookies") // Set the default authentication scheme
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Login"; // Path for the login page
        // options.LogoutPath = "/Account/Logout"; // Path for logout
        // options.AccessDeniedPath = "/Account/AccessDenied"; // Path for access denied
    });
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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
