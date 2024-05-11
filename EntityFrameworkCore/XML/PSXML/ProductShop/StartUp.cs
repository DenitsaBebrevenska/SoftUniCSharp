using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();
            string inputXml = File.ReadAllText(@"../../../Datasets/categories.xml");

            //task 01
            //Console.WriteLine(ImportUsers(context, inputXml));

            //task 02
            //Console.WriteLine(ImportProducts(context, inputXml));

            //task 03
            //Console.WriteLine(ImportCategories(context, inputXml));

            //task 04
            Console.WriteLine();
        }

        private static IMapper InitializeMapper()
        {
            return new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<ProductShopProfile>()));
        }

        //task 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var mapper = InitializeMapper();
            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), root);
            using StringReader reader = new StringReader(inputXml);
            var users = (ImportUserDto[])serializer.Deserialize(reader);
            var validUsers = new HashSet<User>();

            foreach (var dto in users)
            {
                validUsers.Add(mapper.Map<User>(dto));
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //task 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "Products";

            var products = xmlHelper.Deserialize<ImportProductDto[]>(inputXml, rootName);
            var validProducts = new HashSet<Product>();

            foreach (var dto in products)
            {
                validProducts.Add(mapper.Map<Product>(dto));
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //task 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "Categories";
            var categories = xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, rootName);
            var validCategories = new HashSet<Category>();

            foreach (var dto in categories)
            {
                validCategories.Add(mapper.Map<Category>(dto));
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //task 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {

        }
    }
}