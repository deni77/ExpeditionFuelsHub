
using ExpeditionFuelsHub.Core.Contracts;
using ExpeditionFuelsHub.Infrastrucure;
using ExpeditionFuelsHub.Infrastrucure.Data;
using ExpeditionFuelsHub.ModelBinders;
using ExpeditionFuelsHub.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//// proba
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    })
      .AddRoles<IdentityRole>()
      .AddRoleManager<RoleManager<IdentityRole>>()
      .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.ConfigureApplicationCookie(options => 
{
    options.LoginPath = "/User/Login";
    options.LogoutPath = "/User/Logout";
});




builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    });;

//services
//builder.Services.AddTransient<IBillLadingService, BillLadingService>(); // be6e AddScoped
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();// dobavih
}
else
{
    app.UseExceptionHandler("/Home/Error");
   app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
