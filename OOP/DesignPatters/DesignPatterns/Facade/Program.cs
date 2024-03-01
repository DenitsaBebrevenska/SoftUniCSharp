using Facade;

var car = new CarBuilderFacade()
    .Info
     .WithType("Audi")
     .WithColor("White")
     .WithNumberOfDoors(4)
    .Built
     .InCity("Ingolstadt")
     .AtAddress("Ettinger Strasse,Germany, 85045")
    .Build();

Console.WriteLine(car);

