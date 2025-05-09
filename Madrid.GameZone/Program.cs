

using ExaminationSystem.MVC.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:80"); 
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                            ?? throw new InvalidOperationException("No Connection String Was Found");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
// when you need to resolve ICategoriesService use the implementation class CategoriesService;
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IDevicesService, DevicesService>();
builder.Services.AddScoped<IGamesService, GamesService>();
builder.Services.AddScoped<IImageService, ImageKitService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
