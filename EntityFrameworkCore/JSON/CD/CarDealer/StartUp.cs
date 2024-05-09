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
            //string inputJson = File.ReadAllText(@"../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, inputJson));
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
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);
            var partsCar = new HashSet<PartCar>();
            var cars = new HashSet<Car>();

            foreach (var dto in carDtos)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TravelledDistance
                };

                cars.Add(car);

                foreach (var partId in dto.PartsId.Distinct()) //used distinct because of duplication part ids
                {
                    partsCar.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }

            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCar);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }
    }
}