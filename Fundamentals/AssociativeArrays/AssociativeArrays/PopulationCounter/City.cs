namespace PopulationCounter;

internal class City
{
	public string Name { get; set; }
	public long Population { get; set; }

	public City(string name, long population)
	{
		Name = name;
		Population = population;
	}
}