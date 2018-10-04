using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OnlineShop.ApplicationCore.Entities;

namespace OnlineShop.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!catalogContext.CatalogBrands.Any())
                {
                    catalogContext.CatalogBrands.AddRange(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogTypes.Any())
                {
                    catalogContext.CatalogTypes.AddRange(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogItems.Any())
                {
                    catalogContext.CatalogItems.AddRange(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>
            {
                new CatalogBrand { Brand = "Sony"},
                new CatalogBrand { Brand = "Microsoft" },
                new CatalogBrand { Brand = "Nintendo" },
                new CatalogBrand { Brand = "NVidia" }, 
                new CatalogBrand { Brand = "Other" }
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>
            {
                new CatalogType { Type = "Stationary"},
                new CatalogType { Type = "Portable" },
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>
            {
                new CatalogItem { CatalogTypeId=1,CatalogBrandId=1, Description = "Sony PlayStation 4 Pro (PS4 Pro) 1TB Black", Name = "Sony PlayStation 4 Pro (PS4 Pro) 1TB Black", Price = 499.99M, PictureUri = "http://catalogbaseurltobereplaced/images/products/1.jpg" },
                new CatalogItem { CatalogTypeId=1,CatalogBrandId=1, Description = "Sony PlayStation 4 Slim (PS4 Slim) 500GB", Name = "Sony PlayStation 4 Slim (PS4 Slim) 500GB", Price= 299.99M, PictureUri = "http://catalogbaseurltobereplaced/images/products/2.jpg" },
                new CatalogItem { CatalogTypeId=1,CatalogBrandId=2, Description = "Microsoft Xbox One X 1TB", Name = "Microsoft Xbox One X 1TB", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/3.jpg" },
                new CatalogItem { CatalogTypeId=1,CatalogBrandId=3, Description = "Microsoft Xbox One S 500GB", Name = "Microsoft Xbox One S 500GB", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/4.jpg" },
                new CatalogItem { CatalogTypeId=1,CatalogBrandId=2, Description = "Microsoft Xbox One S 1TB", Name = "Microsoft Xbox One S 1TB", Price = 8.5M, PictureUri = "http://catalogbaseurltobereplaced/images/products/5.jpg" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=3, Description = "Nintendo Switch with Neon Blue and Neon Red Joy-Con", Name = "Nintendo Switch with Neon Blue and Neon Red Joy-Con", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/6.jpg" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=3, Description = "Nintendo Switch with Gray Joy Con", Name = "Nintendo Switch with Gray Joy Con", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/7.jpg"  },
                new CatalogItem { CatalogTypeId=1,CatalogBrandId=1, Description = "Sony PlayStation 4 Pro 1TB Limited Edition Marvel's Spider-Man", Name = "Sony PlayStation 4 Pro 1TB Limited Edition Marvel's Spider-Man", Price = 8.5M, PictureUri = "http://catalogbaseurltobereplaced/images/products/8.jpg" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=3, Description = "Nintendo 3DS XL", Name = "Nintendo 3DS XL", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/9.jpg" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=4, Description = "NVIDIA Shield", Name = "NVIDIA Shield", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/10.jpg" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=1, Description = "Sony PlayStation Vita (Wi-Fi)", Name = "Sony PlayStation Vita (Wi-Fi)", Price = 8.5M, PictureUri = "http://catalogbaseurltobereplaced/images/products/11.jpg" },
                new CatalogItem { CatalogTypeId=2,CatalogBrandId=3, Description = "Nintendo New 2DS XL White & Orange", Name = "Nintendo New 2DS XL White & Orange", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/12.jpg" }
            };
        }
    }
}
