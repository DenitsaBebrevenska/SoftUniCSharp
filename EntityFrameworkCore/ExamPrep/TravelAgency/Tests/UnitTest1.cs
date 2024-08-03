//Resharper disable InconsistentNaming, CheckNamespace

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture] //JSON!!!
public class Export_002
{
    private IServiceProvider serviceProvider;
    private static Assembly CurrentAssembly = typeof(StartUp).Assembly;

    [SetUp]
    public void Setup()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TravelAgencyProfile>();
        });

        var uniqueDbName = $"TravelAgencyDb_{Guid.NewGuid()}";

        this.serviceProvider = ConfigureServices<TravelAgencyContext>(uniqueDbName);
    }

    [Test]
    public void ExportPatientsWithTheirMedicinesTest()
    {
        var context = serviceProvider.GetService<TravelAgencyContext>();

        SeedDatabase(context);

        var actualJson = Serializer.ExportCustomersThatHaveBookedHorseRidingTourPackage(context);

        var actualOutput = JToken.Parse(actualJson);

        string expectedJSon =
        "[{\"FullName\":\"Donald Sanders\",\"PhoneNumber\":\"+357683444233\",\"Bookings\":[{\"TourPackageName\":\"Horse Riding Tour\",\"Date\":\"2024-09-21\"}]},{\"FullName\":\"Henry White\",\"PhoneNumber\":\"+357611144251\",\"Bookings\":[{\"TourPackageName\":\"Horse Riding Tour\",\"Date\":\"2024-09-28\"}]},{\"FullName\":\"Michael Smith\",\"PhoneNumber\":\"+357683411237\",\"Bookings\":[{\"TourPackageName\":\"Horse Riding Tour\",\"Date\":\"2024-09-15\"}]},{\"FullName\":\"William Garcia\",\"PhoneNumber\":\"+317683444239\",\"Bookings\":[{\"TourPackageName\":\"Horse Riding Tour\",\"Date\":\"2024-11-01\"}]}]";

        var expectedOutput = JToken.Parse(expectedJSon);

        var expectedResult = expectedOutput.ToString(Newtonsoft.Json.Formatting.None);
        var actualResult = actualOutput.ToString(Newtonsoft.Json.Formatting.None);

        Assert.That(actualResult, Is.EqualTo(expectedResult).NoClip,
        $"{nameof(Serializer.ExportCustomersThatHaveBookedHorseRidingTourPackage)} output is incorrect!");
    }
    private static void SeedDatabase(TravelAgencyContext context)
    {
        var customersJson = "{\"Customer\":[{\"FullName\":\"Donald Sanders\",\"Email\":\"donald.sanders@mail.lt\",\"PhoneNumber\":\"+357683444233\"},{\"FullName\":\"Alice Johnson\",\"Email\":\"alice.johnson@mail.du\",\"PhoneNumber\":\"+357183414234\"},{\"FullName\":\"John Doe\",\"Email\":\"john.doe@mail.dm\",\"PhoneNumber\":\"+357683444035\"},{\"FullName\":\"Emma Brown\",\"Email\":\"emma.brown@mail.dm\",\"PhoneNumber\":\"+357600444236\"},{\"FullName\":\"Michael Smith\",\"Email\":\"michael.smith@mail.eu\",\"PhoneNumber\":\"+357683411237\"},{\"FullName\":\"Olivia Davis\",\"Email\":\"olivia.davis@mail.dm\",\"PhoneNumber\":\"+357683664238\"},{\"FullName\":\"William Garcia\",\"Email\":\"william.garcia@mail.cc\",\"PhoneNumber\":\"+317683444239\"},{\"FullName\":\"Ava Martinez\",\"Email\":\"ava.martinez@mail.rr\",\"PhoneNumber\":\"+257683444240\"},{\"FullName\":\"James Invalid\",\"Email\":\"james.rodriguez@mail.ai\",\"PhoneNumber\":\"+357101444236\"},{\"FullName\":\"Sophia Wilson\",\"Email\":\"sophia.wilson@mail.mm\",\"PhoneNumber\":\"+357683884242\"},{\"FullName\":\"Benjamin Lee\",\"Email\":\"benjamin.lee@mail.nm\",\"PhoneNumber\":\"+357683904243\"},{\"FullName\":\"Isabella Harris\",\"Email\":\"isabella.harris@mail.im\",\"PhoneNumber\":\"+357683234244\"},{\"FullName\":\"Lucas Clark\",\"Email\":\"lucas.clark@mail.om\",\"PhoneNumber\":\"+357683324245\"},{\"FullName\":\"Ethan Anderson\",\"Email\":\"ethan.anderson@mail.dm\",\"PhoneNumber\":\"+357682224247\"},{\"FullName\":\"Charlotte Taylor\",\"Email\":\"charlotte.taylor@mail.dm\",\"PhoneNumber\":\"+357688884248\"},{\"FullName\":\"Daniel Moore\",\"Email\":\"daniel.moore@mail.dm\",\"PhoneNumber\":\"+357683994249\"},{\"FullName\":\"Amelia Martinez\",\"Email\":\"amelia.martinez@mail.dm\",\"PhoneNumber\":\"+357680044250\"},{\"FullName\":\"Henry White\",\"Email\":\"henry.white@mail.dm\",\"PhoneNumber\":\"+357611144251\"},{\"FullName\":\"Alexander Brown\",\"Email\":\"alexander.brown@mail.dm\",\"PhoneNumber\":\"+357685644253\"},{\"FullName\":\"Victoria Scott\",\"Email\":\"victoria.scott@mail.dm\",\"PhoneNumber\":\"+357688744254\"},{\"FullName\":\"Christopher Lee\",\"Email\":\"christopher.lee@mail.dm\",\"PhoneNumber\":\"+357683744255\"}]}";

        var guidesJson = "{\"Guide\":[{\"Id\":1,\"FullName\":\"John Doe\",\"Language\":\"Russian\"},{\"Id\":2,\"FullName\":\"Jane Smith\",\"Language\":\"English\"},{\"Id\":3,\"FullName\":\"Alex Johnson\",\"Language\":\"Spanish\"},{\"Id\":4,\"FullName\":\"Emily Davis\",\"Language\":\"French\"},{\"Id\":5,\"FullName\":\"Michael Brown\",\"Language\":\"German\"},{\"Id\":6,\"FullName\":\"Sarah Wilson\",\"Language\":\"Russian\"},{\"Id\":7,\"FullName\":\"David Lee\",\"Language\":\"English\"},{\"Id\":8,\"FullName\":\"Laura Garcia\",\"Language\":\"German\"},{\"Id\":9,\"FullName\":\"Chris Martin\",\"Language\":\"Spanish\"},{\"Id\":10,\"FullName\":\"Anna Thompson\",\"Language\":\"French\"}]}";

        var tourPackagesJson = "{\"TourPackage\":[{\"Id\":1,\"PackageName\":\"Horse Riding Tour\",\"Description\":\"Experience the thrill of a guided horse riding tour through picturesque landscapes. Suitable for all skill levels. Enjoy nature and create unforgettable memories. Duration: 3 hours.\",\"Price\":199.99},{\"Id\":2,\"PackageName\":\"Sightseeing Tour\",\"Description\":\"Explore the city's top attractions with a guided sightseeing tour. Visit historical landmarks, iconic buildings, and scenic spots. Perfect for all ages. Duration: 4 hours.\",\"Price\":149.99},{\"Id\":3,\"PackageName\":\"Diving Tour\",\"Description\":\"Dive into the crystal-clear waters and explore vibrant coral reefs and marine life. Suitable for beginners and experienced divers. Equipment provided. Duration: 2 hours.\",\"Price\":299.99},{\"Id\":4,\"PackageName\":\"Mountain Hiking\",\"Description\":\"Embark on an exhilarating mountain hiking tour. Enjoy breathtaking views, fresh air, and challenging trails. Suitable for all fitness levels. Duration: 5 hours.\",\"Price\":179.99},{\"Id\":5,\"PackageName\":\"City Tour\",\"Description\":\"Discover the charm of the city with a guided tour. Visit famous landmarks, bustling markets, and hidden gems. Perfect for all ages. Duration: 3 hours.\",\"Price\":129.99},{\"Id\":6,\"PackageName\":\"Food Tour\",\"Description\":\"Savor the local flavors on a guided food tour. Taste a variety of dishes, visit top eateries, and learn about the culinary culture. Suitable for all food lovers. Duration: 3 hours.\",\"Price\":99.99},{\"Id\":7,\"PackageName\":\"Wildlife Safari\",\"Description\":\"Embark on an exciting wildlife safari. Spot exotic animals in their natural habitat, guided by experts. Perfect for nature enthusiasts. Duration: 4 hours.\",\"Price\":249.99},{\"Id\":8,\"PackageName\":\"Historical Sites\",\"Description\":\"Explore ancient ruins, museums, and landmarks on a guided tour. Learn about the rich history and culture of the area. Ideal for history buffs. Duration: 4 hours.\",\"Price\":159.99},{\"Id\":9,\"PackageName\":\"Sunset Cruise\",\"Description\":\"Experience a breathtaking sunset on a luxury cruise. Enjoy stunning views, delicious refreshments, and a relaxing atmosphere. Perfect for couples and families. Duration: 2 hours.\",\"Price\":399.99}]}";

        var tourPackagesGuidesJson = "{\"TourPackageGuide\":[{\"TourPackageId\":1,\"GuideId\":1},{\"TourPackageId\":1,\"GuideId\":2},{\"TourPackageId\":1,\"GuideId\":3},{\"TourPackageId\":2,\"GuideId\":4},{\"TourPackageId\":2,\"GuideId\":5},{\"TourPackageId\":2,\"GuideId\":6},{\"TourPackageId\":3,\"GuideId\":7},{\"TourPackageId\":3,\"GuideId\":8},{\"TourPackageId\":3,\"GuideId\":9},{\"TourPackageId\":4,\"GuideId\":10},{\"TourPackageId\":4,\"GuideId\":1},{\"TourPackageId\":4,\"GuideId\":2},{\"TourPackageId\":5,\"GuideId\":3},{\"TourPackageId\":5,\"GuideId\":4},{\"TourPackageId\":5,\"GuideId\":5},{\"TourPackageId\":6,\"GuideId\":6},{\"TourPackageId\":6,\"GuideId\":7},{\"TourPackageId\":6,\"GuideId\":8},{\"TourPackageId\":7,\"GuideId\":9},{\"TourPackageId\":7,\"GuideId\":10},{\"TourPackageId\":7,\"GuideId\":1},{\"TourPackageId\":8,\"GuideId\":2},{\"TourPackageId\":8,\"GuideId\":3},{\"TourPackageId\":8,\"GuideId\":4},{\"TourPackageId\":9,\"GuideId\":5},{\"TourPackageId\":9,\"GuideId\":6},{\"TourPackageId\":9,\"GuideId\":7}]}";

        var bookingsJson = "{\"Booking\":[{\"BookingDate\":\"2024-09-21\",\"CustomerId\":\"1\",\"TourPackageId\":\"1\"},{\"BookingDate\":\"2024-09-22\",\"CustomerId\":\"1\",\"TourPackageId\":\"2\"},{\"BookingDate\":\"2024-10-01\",\"CustomerId\":\"7\",\"TourPackageId\":\"8\"},{\"BookingDate\":\"2024-11-01\",\"CustomerId\":\"7\",\"TourPackageId\":\"1\"},{\"BookingDate\":\"2024-09-20\",\"CustomerId\":\"7\",\"TourPackageId\":\"2\"},{\"BookingDate\":\"2024-12-06\",\"CustomerId\":\"7\",\"TourPackageId\":\"8\"},{\"BookingDate\":\"2024-09-15\",\"CustomerId\":\"5\",\"TourPackageId\":\"1\"},{\"BookingDate\":\"2024-09-23\",\"CustomerId\":\"5\",\"TourPackageId\":\"8\"},{\"BookingDate\":\"2024-09-27\",\"CustomerId\":\"18\",\"TourPackageId\":\"9\"},{\"BookingDate\":\"2024-09-28\",\"CustomerId\":\"18\",\"TourPackageId\":\"1\"},{\"BookingDate\":\"2024-09-29\",\"CustomerId\":\"18\",\"TourPackageId\":\"7\"},{\"BookingDate\":\"2024-09-30\",\"CustomerId\":\"18\",\"TourPackageId\":\"9\"},{\"BookingDate\":\"2024-10-05\",\"CustomerId\":\"17\",\"TourPackageId\":\"2\"},{\"BookingDate\":\"2024-5-5\",\"CustomerId\":\"17\",\"TourPackageId\":\"2\"},{\"BookingDate\":\"2024-10-08\",\"CustomerId\":\"17\",\"TourPackageId\":\"3\"},{\"BookingDate\":\"2024-10-03\",\"CustomerId\":\"19\",\"TourPackageId\":\"7\"},{\"BookingDate\":\"2024-10-04\",\"CustomerId\":\"19\",\"TourPackageId\":\"9\"},{\"BookingDate\":\"2024-10-05\",\"CustomerId\":\"20\",\"TourPackageId\":\"6\"},{\"BookingDate\":\"2024-10-05\",\"TourPackageId\":\"6\"},{\"BookingDate\":\"2024-10-06\",\"CustomerId\":\"20\",\"TourPackageId\":\"7\"},{\"BookingDate\":\"2024-10-07\",\"CustomerId\":\"21\",\"TourPackageId\":\"3\"},{\"BookingDate\":\"2024-10-08\",\"CustomerId\":\"10\",\"TourPackageId\":\"3\"},{\"BookingDate\":\"2024-10-08\",\"CustomerId\":\"10\"},{\"BookingDate\":\"2024-11-09\",\"CustomerId\":\"11\",\"TourPackageId\":\"6\"},{\"BookingDate\":\"2024-10-03\",\"CustomerId\":\"11\",\"TourPackageId\":\"5\"},{\"BookingDate\":\"2024-11-11\",\"CustomerId\":\"12\",\"TourPackageId\":\"5\"},{\"BookingDate\":\"2024-10-12\",\"CustomerId\":\"15\",\"TourPackageId\":\"4\"},{\"BookingDate\":\"2024-10-13\",\"CustomerId\":\"16\",\"TourPackageId\":\"4\"}]}";

        var datasetsCustomers = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<JObject>>>(customersJson);

        foreach (var dataset in datasetsCustomers)
        {
            var entityType = GetType(dataset.Key);
            var entities = dataset.Value
                .Select(j => j.ToObject(entityType))
                .ToArray();

            context.AddRange(entities);
        }

        var datasetsGuides = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<JObject>>>(guidesJson);

        foreach (var dataset in datasetsGuides)
        {
            var entityType = GetType(dataset.Key);
            var entities = dataset.Value
                .Select(j => j.ToObject(entityType))
                .ToArray();

            context.AddRange(entities);
        }

        var datasetsTourPackages = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<JObject>>>(tourPackagesJson);

        foreach (var dataset in datasetsTourPackages)
        {
            var entityType = GetType(dataset.Key);
            var entities = dataset.Value
                .Select(j => j.ToObject(entityType))
                .ToArray();

            context.AddRange(entities);
        }

        var datasetsTourPackagesGuides = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<JObject>>>(tourPackagesGuidesJson);

        foreach (var dataset in datasetsTourPackagesGuides)
        {
            var entityType = GetType(dataset.Key);
            var entities = dataset.Value
                .Select(j => j.ToObject(entityType))
                .ToArray();

            context.AddRange(entities);
        }

        var datasetsBookings = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<JObject>>>(bookingsJson);

        foreach (var dataset in datasetsBookings)
        {
            var entityType = GetType(dataset.Key);
            var entities = dataset.Value
                .Select(j => j.ToObject(entityType))
                .ToArray();

            context.AddRange(entities);
        }

        context.SaveChanges();
    }
    private static Type GetType(string modelName)
    {
        var modelType = CurrentAssembly
        .GetTypes()
        .FirstOrDefault(t => t.Name == modelName);
        Assert.IsNotNull(modelType, $"{modelName} model not found!");
        return modelType;
    }
    private static IServiceProvider ConfigureServices<TContext>(string databaseName)
        where TContext : DbContext
    {
        var services = ConfigureDbContext<TContext>(databaseName);
        var context = services.GetService<TContext>();
        try
        {
            context.Model.GetEntityTypes();
        }
        catch (InvalidOperationException ex) when (ex.Source == "Microsoft.EntityFrameworkCore.Proxies")
        {
            services = ConfigureDbContext<TContext>(databaseName, useLazyLoading: true);
        }
        return services;
    }
    private static IServiceProvider ConfigureDbContext<TContext>(string databaseName, bool useLazyLoading = false)
        where TContext : DbContext
    {
        var services = new ServiceCollection()
        .AddDbContext<TContext>(t => t
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        );

        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}