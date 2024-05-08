using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            //task 09 
            //string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, inputJson));

            //task 10
            //string inputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, inputJson));

            //task 11
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
                cfg.AddProfile<CarDealerProfile>()));
        }

        //task 09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();
            var suppliers = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);
            var validSuppliers = new HashSet<Supplier>();

            foreach (var dto in suppliers)
            {
                Supplier supplier = mapper.Map<Supplier>(dto);
                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}.";
        }

        //task 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            //manual mapping because setting a mapper can take longer

            var partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);
            var partsToImport = new HashSet<Part>();

            foreach (var dto in partDtos)
            {
                if (!context.Suppliers.Any(s => s.Id == dto.SupplierId))
                {
                    continue;
                }

                partsToImport.Add(new Part()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                });
            }

            context.Parts.AddRange(partsToImport);
            context.SaveChanges();
            return $"Successfully imported {partsToImport.Count}.";
        }

        //task 11
    }
}