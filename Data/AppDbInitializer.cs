using Microsoft.AspNetCore.Identity;
using Projet_2022.Data.Static;
using Projet_2022.Models.Entities;
using System.Diagnostics.Tracing;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Projet_2022.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(new List<Brand>()
                    {

                         new Brand() { Id="1",Name="Nike",Description="Brand1Description",Logo="https://c.static-nike.com/a/images/w_1920,c_limit/mdbgldn6yg1gg88jomci/image.jpg" },
                         new Brand() { Id="2",Name="Adidas",Description="Brand1Description",Logo="https://c.static-nike.com/a/images/w_1920,c_limit/mdbgldn6yg1gg88jomci/image.jpg" },

                        new Brand() { Id="3",Name="New Balance",Description="Brand2Description",Logo="https://www.impactshoes.com/sites/default/files/styles/zoom_fiche_produit/public/adidas-zx-4000-femme-argent-paillette-rose01.jpg"}
                    });
                    context.SaveChanges();
                }
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Id="1",
                            Name="Women",
                            Slug="Category1Slug",
                            Description="Category1Description",
                            Image="https://img.ltwebstatic.com/images3_pi/2022/05/09/1652060801a1248c91c9349b79c88af8dbdc885271_thumbnail_900x.webp",
                        },
                        new Category()
                        {
                            Id = "2",
                            Name="Man",
                            Slug="Category2Slug",
                            Description="Category2Description",
                            Image="https://www.cdiscount.com/pdt2/2/9/2/1/700x700/mp00062292/rw/nike-basket-homme-air-max-90-noir.jpg"

                        },
                        new Category()
                        {
                            Id="3",
                            Name="Kids",
                            Slug="Category2Slug",
                            Description="Category2Description",
                            Image="https://cdn-images.farfetch-contents.com/16/06/70/71/16067071_30970413_480.jpg" }
                    });
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    { new Product()
                    {
                        Id="1",
                        Sku="Product1Sku",
                        Name="QSD24",
                        Slug="Product1Slug",
                        Description="Product1Description",
                        PrincipalImage="https://img.ltwebstatic.com/images3_pi/2021/12/23/1640225750973df23ec24bef48770dbee17794ff6b_thumbnail_900x.webp",
                        Ratings=10,
                        Price=1,
                        AddedAt=DateTime.Now,
                        UpdatedAt=DateTime.Now,
                        DeletedAt=DateTime.Now,
                        TotalSales=0,
                        StockStatus=10,
                        IdBrand="1",
                        IdCategory="1",
                    },new Product()
                    {
                        Id="2",
                        Sku="Product2Sku",
                        Name="HGK234",
                        Slug="Product2Slug",
                         PrincipalImage="https://www.cdiscount.com/pdt2/2/9/2/1/700x700/mp00062292/rw/nike-basket-homme-air-max-90-noir.jpg",
                        Ratings=10,
                        Price=2,
                        AddedAt=DateTime.Now,
                        UpdatedAt=DateTime.Now,
                        DeletedAt=DateTime.Now,
                        TotalSales=0,
                        StockStatus=10,
                        IdBrand="1",
                        Description="Description2",
                        IdCategory="2",

                    },new Product()
                    {
                        Id="3",
                        Sku="Product3Sku",
                        Name="XWV354",
                        Slug="Product3Slug",
                        PrincipalImage="https://cdn-images.farfetch-contents.com/18/39/68/32/18396832_39757641_480.jpg",

                        Description="Product3Description",
                        Ratings=10,
                        Price=2,
                        AddedAt=DateTime.Now,
                        UpdatedAt=DateTime.Now,
                        DeletedAt=DateTime.Now,
                        TotalSales=0,
                        StockStatus=10,
                        IdBrand="1",
                        IdCategory="3",
                    }}); ;
                    context.SaveChanges();
                }
                if (!context.OrderItems.Any())
                {
                    context.OrderItems.AddRange(
                    new OrderItem()
                    {
                        Id = "1",
                        Amount = 3,
                        Price = 3,
                        IdProduct = "1",
                        IdOrder = "1",
                    },
                    new OrderItem()
                    {
                        Id = "2",
                        Amount = 4,
                        Price = 8,
                        IdProduct = "2",
                        IdOrder = "1"
                    });
                }
                if (!context.Orders.Any())
                {
                    context.AddRange(new List<Order>
                    {
                        new Order()
                        {
                            Id="1",
                            ShipAddress="france",
                            City="grenoble",
                            ZipCode="3000",
                            Tax=18/100,
                            Shipped=0,
                            TrackingNumber=33,
                            DateOfOrder=DateTime.Now,
                            Email="Order1@order.com",
                            Phone="123",
                            IdUser="1"
                        },
                        new Order()
                        {
                            Id="2",

                            ShipAddress="france",
                            City="paris",
                            ZipCode="4000",
                            Tax=18/100,
                            Shipped=0,
                            TrackingNumber=34,
                            DateOfOrder=DateTime.Now,
                            Email="Order1@order.com",
                            Phone ="123",
                            IdUser="1"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Jobs.Any())
                {
                    context.Jobs.AddRange(
                        new Job()
                        {
                            Id = "1",
                            JobTitle = "Worker"
                        }
                        ); ;
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationbuilder)
        {
            using (var serviceScope = applicationbuilder.ApplicationServices.CreateScope())
            {

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                #region roles
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Employee))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));
                if (!await roleManager.RoleExistsAsync(UserRoles.Client))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Client));

                #endregion

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

                #region user1
                string user1Email = "user1@p22.com";
                var user1 = await userManager.FindByEmailAsync(user1Email);
                if (user1 == null)
                {
                    var newUser1 = new User()
                    {
                        Id = "1",
                        FirstName = "User1FirstName",
                        LastName = "User1LastName",
                        Email = user1Email,
                        City = "User1City",
                        Zipcode = "User1Zipcode",
                        EmailVerification = false,
                        Phone = "12345678",
                        UserName = user1Email,
                        Address = "Moghrib"
                    };
                    await userManager.CreateAsync(newUser1, "User1123@");
                    await userManager.AddToRoleAsync(newUser1, UserRoles.Client);
                }
                #endregion

                #region admin
                string useradminemail = "useradmin@p22.com";

                var useradmin = await userManager.FindByEmailAsync(useradminemail);
                if (useradmin == null)
                {
                    var newUser2 = new User()
                    {
                        Id = "2",
                        FirstName = "UserAdminFirstName",
                        LastName = "UserAdminLastName",
                        Email = useradminemail,
                        City = "UserAdminCity",
                        Zipcode = "UserAdminZipCode",
                        EmailVerification = false,
                        Phone = "123456789",
                        UserName = useradminemail,
                        Address = "Moghrib"
                    };
                    await userManager.CreateAsync(newUser2, "Useradmin123@");
                    await userManager.AddToRoleAsync(newUser2, UserRoles.Admin);
                }
                #endregion
            }
        }
    }
}
