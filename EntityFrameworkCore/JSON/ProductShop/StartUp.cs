using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
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
            string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            Console.WriteLine(ImportCategories(context, inputJson));
        }

        private static IMapper CreateMapper()
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            return mapper;
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
    }
}