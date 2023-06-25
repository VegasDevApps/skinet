using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        private static string pathToData = "../Infrastructure/Data/SeedData/";
        public static async Task SeedAsync(StoreContext context)
        {

            if(!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText($"{pathToData}brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }
            if(!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText($"{pathToData}types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }
            if(!context.ProductBrands.Any())
            {
                var productsData = File.ReadAllText($"{pathToData}products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

            if(context.ChangeTracker.HasChanges())
                await context.SaveChangesAsync();
        }    
    }
}