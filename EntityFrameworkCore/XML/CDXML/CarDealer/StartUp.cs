using AutoMapper;
using CarDealer.Data;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();
            string inputXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");

            //task 09
            Console.WriteLine(ImportSuppliers(context, inputXml));
        }

        private static IMapper InitializeMapper()
            => new Mapper(new MapperConfiguration(cfg =>
                cfg.AddProfile(new CarDealerProfile())));

        //task 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var mapper = InitializeMapper();




            return $"Successfully imported {suppliers.Count}";
        }
    }
}