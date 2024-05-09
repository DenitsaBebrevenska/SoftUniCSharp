using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
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

            //task 12 
            //string inputJson = File.ReadAllText(@"../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, inputJson));

            //task 13
            //string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, inputJson));

            //task 14
            //Console.WriteLine(GetOrderedCustomers(context));

            //task 15
            Console.WriteLine();
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

        //task 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();
            var customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);
            var customers = new HashSet<Customer>();

            foreach (var dto in customerDtos)
            {
                customers.Add(mapper.Map<ImportCustomerDto, Customer>(dto));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}.";
        }

        //task 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();
            var salesDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);
            var sales = new HashSet<Sale>();

            foreach (var dto in salesDtos)
            {
                sales.Add(mapper.Map<Sale>(dto));
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //task 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var mapper = CreateMapper();
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver) //that will order them by false first
                .AsNoTracking();

            //Honestly, I can do just one CustomerDTO for export and import but keeping them separate for the principle of it
            var customerDtos = mapper.ProjectTo<ExportCustomerDto>(customers);

            return JsonConvert.SerializeObject(customerDtos, Formatting.Indented);
        }

        //task 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var mapper = CreateMapper();

        }
    }

}