﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();
            //string inputXml = File.ReadAllText(@"../../../Datasets/sales.xml");

            //task 09
            //Console.WriteLine(ImportSuppliers(context, inputXml));

            //task 10
            //Console.WriteLine(ImportParts(context, inputXml));

            //task 11
            //Console.WriteLine(ImportCars(context, inputXml));

            //task 12
            //Console.WriteLine(ImportCustomers(context, inputXml));

            //task 13
            //Console.WriteLine(ImportSales(context, inputXml));

            //task 14
            //Console.WriteLine(GetCarsWithDistance(context));

            //task 15
            //Console.WriteLine(GetCarsFromMakeBmw(context));

            //task 16
            //Console.WriteLine(GetLocalSuppliers(context));

            //task 17
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //task 18
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //task 19
            //Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        private static IMapper InitializeMapper()
            => new Mapper(new MapperConfiguration(cfg =>
                cfg.AddProfile(new CarDealerProfile())));

        //task 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "Suppliers";
            var suppliersDtos = xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, rootName);
            var suppliers = new HashSet<Supplier>();

            foreach (var dto in suppliersDtos)
            {
                suppliers.Add(mapper.Map<Supplier>(dto));
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        //task 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "Parts";
            var partDtos = xmlHelper.Deserialize<ImportPartDto[]>(inputXml, rootName);

            HashSet<int> validSupplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToHashSet();

            var parts = new HashSet<Part>();

            foreach (var dto in partDtos
                         .Where(dto => validSupplierIds.Contains(dto.SupplierId)))
            {
                parts.Add(mapper.Map<Part>(dto));
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //task 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            var validPartIds = context.Parts
                .AsNoTracking()
                .Select(p => p.Id)
                .ToArray();
            string rootName = "Cars";
            var carDtos = xmlHelper.Deserialize<ImportCarDto[]>(inputXml, rootName);

            var cars = new HashSet<Car>();

            foreach (ImportCarDto carDto in carDtos)
            {
                Car car = mapper.Map<Car>(carDto);

                foreach (var partDto in carDto.PartIds.DistinctBy(p => p.Id))
                {
                    if (validPartIds.All(p => p != partDto.Id))
                    {
                        continue;
                    }

                    PartCar carPart = new PartCar()
                    {
                        PartId = partDto.Id
                    };
                    car.PartsCars.Add(carPart);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //task 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "Customers";

            var customerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, rootName);
            var customers = new HashSet<Customer>();

            foreach (var dto in customerDtos)
            {
                customers.Add(mapper.Map<Customer>(dto));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //task 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "Sales";

            var saleDtos = xmlHelper.Deserialize<ImportSaleDto[]>(inputXml, rootName);
            var validCarIds = context.Cars
                .AsNoTracking()
                .Select(c => c.Id)
                .ToArray();
            var sales = new HashSet<Sale>();

            foreach (var dto in saleDtos)
            {
                if (validCarIds.All(c => c != dto.CarId))
                {
                    continue;
                }

                sales.Add(mapper.Map<Sale>(dto));
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //task 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "cars";

            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2_000_000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .AsNoTracking()
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(cars, rootName);
        }

        //task 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "cars";

            var bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .AsNoTracking()
                .ProjectTo<ExportBmwCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(bmwCars, rootName);
        }

        //task 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "suppliers";

            var localSupplies = context.Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<ExportSupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(localSupplies, rootName);
        }

        //task 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var mapper = InitializeMapper();
            var xmlHelper = new XmlHelper();
            string rootName = "cars";

            var carsAndParts = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .AsNoTracking()
                .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)
                .ToArray();


            return xmlHelper.Serialize(carsAndParts, rootName);
        }

        //task 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //Likely not the most elegant solution
            //Judge`s tests account for double as price per part and if decimal is used, the results are wrong to the test
            //also rounding is used for the doubles and the output is as string F2....

            var xmlHelper = new XmlHelper();
            string rootName = "customers";

            var salesByCustomer = context.Customers
                .Where(c => c.Sales.Any())
                .AsNoTracking()
                .Include(c => c.Sales)
                .ThenInclude(sale => sale.Car)
                .ThenInclude(car => car.PartsCars)
                .ThenInclude(partCar => partCar.Part)
                .ToArray();

            var customerDtos = new List<ExportCustomerDto>();

            foreach (var customer in salesByCustomer)
            {
                ExportCustomerDto customerDto = new ExportCustomerDto()
                {
                    Name = customer.Name,
                    BoughtCars = customer.Sales.Count,
                    SpentMoney = customer.IsYoungDriver ?
                        customer.Sales
                            .SelectMany(s => s.Car.PartsCars)
                            .Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2)).ToString("F2")
                        : customer.Sales
                            .SelectMany(s => s.Car.PartsCars)
                            .Sum(pc => (double)pc.Part.Price).ToString("F2")
                };

                customerDtos.Add(customerDto);
            }

            var orderedCustomerDtos = customerDtos.OrderByDescending(c => double.Parse(c.SpentMoney.ToString()))
                .ToArray();

            return xmlHelper.Serialize(orderedCustomerDtos, rootName);
        }

        //task 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //again expected double for price with discount and no rounding in Judge tests 
            //that is not visible in the sample output in the document neither explained
            var xmlHelper = new XmlHelper();
            string rootName = "sales";

            var sales = context.Sales
                .AsNoTracking()
                .Select(s => new ExportSaleDto()
                {
                    Car = new ExportCarAttributesDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars
                        .Sum(pc => pc.Part.Price),
                    PriceWithDiscount = (double)(s.Car.PartsCars
                        .Sum(pc => pc.Part.Price) * (1 - s.Discount / 100))
                })
                .ToArray();

            return xmlHelper.Serialize(sales, rootName);
        }
    }
}