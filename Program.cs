using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projet_2022.Data;
using Projet_2022.Data.Cart;
using Projet_2022.Data.Extensions;
using Projet_2022.Data.IServices;
using Projet_2022.Data.Services;
using Projet_2022.Models.Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>(option => option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.



#region Services
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IBrandService,BrandService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductGalleryImageService, ProductGalleryImageService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(c => Cart.GetCart(c));
builder.Services.AddSession();

#endregion

builder.Services.AddControllersWithViews();


#region Claims
builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, ApplicationUserClaimsPrincipalFactory>();
#endregion



#region Services related to authentification and authorization
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});
builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("Admin",
        authBuilder =>
        {
            authBuilder.RequireRole("Admin");
        });

});
builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("Employee",
        authBuilder =>
        {
            authBuilder.RequireRole("Employee");
        });

});
#endregion  
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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
AppDbInitializer.Seed(app);

app.Run();