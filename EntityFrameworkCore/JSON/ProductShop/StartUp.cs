using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();

            //Mapper cannot be field because of Judge, calling it in every method because of Judge`s tests

            //task 01
            //string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, inputJson));

            //task 02
            //string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, inputJson));

            //task 03
            //string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, inputJson));

            //task 04
            //string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(context, inputJson));

            //task 05
            //Console.WriteLine(GetProductsInRange(context));

            //task 06
            //anonymous type would be faster  for export Json
            //Console.WriteLine(GetSoldProducts(context));

            //task 07
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //task 08
            //Console.WriteLine(GetUsersWithProducts(context));
        }

        private static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            return mapper;
        }

        private static IContractResolver CreateContractResolver()
        {
            return new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
        }

        //task 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var mapper = CreateMapper();
            var importDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);
            var users = new HashSet<User>();

            foreach (var dto in importDtos)
            {
                User user = mapper.Map<User>(dto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //task 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
            var products = new HashSet<Product>();

            foreach (var dto in productDtos)
            {
                Product product = mapper.Map<Product>(dto);
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //task 03 
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);
            var categories = new HashSet<Category>();

            foreach (var dto in categoryDtos.Where(d => d.Name != null))
            {
                Category category = mapper.Map<Category>(dto);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //task 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var mapper = CreateMapper();
            var categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);
            var categoriesProducts = new HashSet<CategoryProduct>();

            foreach (var dto in categoryProductDtos)
            {
                CategoryProduct cp = mapper.Map<CategoryProduct>(dto);
                categoriesProducts.Add(cp);
            }

            context.CategoriesProducts.AddRange(categoriesProducts);
            context.SaveChanges();
            return $"Successfully imported {categoriesProducts.Count}";
        }

        //task 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var mapper = CreateMapper();
            var productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ProjectTo<ExportProductRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(productDtos, Formatting.Indented);
        }

        //task 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var mapper = CreateMapper();

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUserSoldProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        //task 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var mapper = CreateMapper();

            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .ProjectTo<ExportCategoryProductCountDto>(mapper.ConfigurationProvider)
                .ToArray();


            string json = JsonConvert.SerializeObject(categories, new JsonSerializerSettings
            {
                ContractResolver = CreateContractResolver(),
                Formatting = Formatting.Indented
            });


            return json;
        }

        //task 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold
                    .Any(p => p.Buyer != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                p.Name,
                                p.Price
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .AsNoTracking()
                .ToArray();

            var userWrapperDto = new
            {
                UsersCount = users.Length,
                Users = users
            };

            return JsonConvert.SerializeObject(userWrapperDto, new JsonSerializerSettings
            {
                ContractResolver = CreateContractResolver(),
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

        }
    }
}