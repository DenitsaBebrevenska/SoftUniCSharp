using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
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
            //string inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");

            //task 01
            //Console.WriteLine(ImportUsers(context, inputXml));

            //task 02
            //Console.WriteLine(ImportProducts(context, inputXml));

            //task 03
            //Console.WriteLine(ImportCategories(context, inputXml));

            //task 04
            //Console.WriteLine(ImportCategoryProducts(context, inputXml));

            //task 05
            //not finished...some tests don`t pass
            //Console.WriteLine(GetProductsInRange(context));

            //task 06
            //Console.WriteLine(GetSoldProducts(context));

            //task 07
            //Console.WriteLine(GetCategoriesByProductsCount(context));
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
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "CategoryProducts";
            var categoriesProducts = xmlHelper.Deserialize<ImportCategoryProductDto[]>(inputXml, rootName);
            var validCategoriesProducts = new HashSet<CategoryProduct>();

            foreach (var dto in categoriesProducts)
            {
                validCategoriesProducts.Add(mapper.Map<CategoryProduct>(dto));
            }

            context.CategoryProducts.AddRange(validCategoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoriesProducts.Count}";
        }

        //task 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Include(p => p.Buyer)
                .AsNoTracking()
                .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
                .ToArray();

            string rootName = "Products";

            //tried both manual and automapper, both fail, it is not the mapping

            return xmlHelper.Serialize(productsInRange, rootName);
        }

        //task 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "Users";


            var usersProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .AsNoTracking()
                .ProjectTo<ExportUserDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(usersProducts, rootName);

        }

        //task 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "Categories";

            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ThenBy(c => c.CategoryProducts.Sum(cp => cp.Product.Price))
                .AsNoTracking()
                .ProjectTo<ExportCategoryDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(categories, rootName);
        }

        //task 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();

            var usersProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Take(10)
                .AsNoTracking()
                .ProjectTo<ExportUserWithAgeDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize();
        }
    }
}