namespace NauticalCatchChallenge.Models.Divers;
public class ScubaDiver : Diver
{
    private const int ScubaDiverOxygen = 540;
    public ScubaDiver(string name)
        : base(name, ScubaDiverOxygen)
    {
    }

    public override void Miss(int timeToCatch)
    {
        double oxygenReduction = timeToCatch * 0.3;
        OxygenLevel -= (int)Math.Round(oxygenReduction, MidpointRounding.AwayFromZero);
    }

    public override void RenewOxy()
    {
        OxygenLevel = ScubaDiverOxygen;
    }
}
