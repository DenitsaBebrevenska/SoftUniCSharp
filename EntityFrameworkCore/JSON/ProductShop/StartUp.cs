using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            //problem 01
            string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            Console.WriteLine(ImportUsers(context, inputJson));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
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
    }
}