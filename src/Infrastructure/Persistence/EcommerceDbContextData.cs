using Ecommerce.Application.Models.Authorization;
using Ecommerce.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ecommerce.Infrastructure.Persistence;

public class EcommerceDbContextData {
    public static async Task LoadDataAsync(
        EcommerceDbContext context,
        UserManager<Usuario> usuarioManager,
        RoleManager<IdentityRole> roleManager,
        ILoggerFactory loggerFactory        
    ){
        try
        {
            if(!roleManager.Roles.Any()){
                await roleManager.CreateAsync(new IdentityRole(Role.ADMIN));
                await roleManager.CreateAsync(new IdentityRole(Role.USER));
            }

            if(!usuarioManager.Users.Any()){
                var usuarioAdmin = new Usuario
                {
                    Name = "Paulo",
                    Apellido = "Silas",
                    Email = "paulo@eu.com",
                    UserName = "paulosilas",
                    Telefone = "33655551",
                    AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/vaxidrez.jpg?alt=media&token=14a28860-d149-461e-9c25-9774d7ac1b24"
                };
                await usuarioManager.CreateAsync(usuarioAdmin, "Pauloosilas@123$");
                await usuarioManager.AddToRoleAsync(usuarioAdmin, Role.ADMIN);


             var usuario = new Usuario
                {
                    Name = "Usuario Normal",
                    Apellido = "Normal",
                    Email = "normal@eu.com",
                    UserName = "norman",
                    Telefone = "336554554",
                    AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/avatar-1.webp?alt=media&token=58da3007-ff21-494d-a85c-25ffa758ff6d"
                };
                await usuarioManager.CreateAsync(usuario, "UsuarioNormal@123$");
                await usuarioManager.AddToRoleAsync(usuario, Role.ADMIN);
            }
        
           
           
            if(!context.Categories!.Any()){
                var categoryData = File.ReadAllText("../Infrastructure/Data/category.json");
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                await context.Categories!.AddRangeAsync(categories!);
                await context.SaveChangesAsync();
              }

             if(!context.Products!.Any()){
                var productData = File.ReadAllText("../Infrastructure/Data/product.json");
                var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                await context.Products!.AddRangeAsync(products!);
                await context.SaveChangesAsync();
              }

             if(!context.Images!.Any()){
                var imageData = File.ReadAllText("../Infrastructure/Data/image.json");
                var imagens = JsonConvert.DeserializeObject<List<Image>>(imageData);
                await context.Images!.AddRangeAsync(imagens!);
                await context.SaveChangesAsync();
              }

            if(!context.Reviews!.Any()){
                var ReviewData = File.ReadAllText("../Infrastructure/Data/review.json");
                var review = JsonConvert.DeserializeObject<List<Review>>(ReviewData);
                await context.Reviews!.AddRangeAsync(review!);
                await context.SaveChangesAsync();
              }

             if(!context.Countries!.Any()){
                var countriesData = File.ReadAllText("../Infrastructure/Data/countries.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(countriesData);
                await context.Countries!.AddRangeAsync(countries!);
                await context.SaveChangesAsync();
              }
        }      

        catch(Exception e){
            var logger = loggerFactory.CreateLogger<EcommerceDbContextData>();
            logger.LogError(e.Message);
        }
    }
}