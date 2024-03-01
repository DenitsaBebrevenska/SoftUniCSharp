namespace NauticalCatchChallenge.Models.Divers;
public class FreeDiver : Diver
{
    private const int FreeDiverOxygen = 120;
    public FreeDiver(string name)
        : base(name, FreeDiverOxygen)
    {
    }

    public override void Miss(int timeToCatch)
    {
        double oxygenReduction = timeToCatch * 0.6;
        OxygenLevel -= (int)Math.Round(oxygenReduction, MidpointRounding.AwayFromZero);
    }

    public override void RenewOxy()
    {
        OxygenLevel = FreeDiverOxygen;
    }
}
