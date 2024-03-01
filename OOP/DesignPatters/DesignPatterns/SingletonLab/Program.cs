using SingletonLab;

var db = SingletonDataContainer.Instance;
Console.WriteLine(db.GetPopulation("Cairo"));
var db2 = SingletonDataContainer.Instance;
Console.WriteLine(db2.GetPopulation("Tokyo"));