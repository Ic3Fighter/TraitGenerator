using TraitGenerator.Models;

namespace TraitGenerator;

internal static class WeightedRandomizer
{
    public static TraitValue Next(List<TraitValue> values)
    {
        var rnd = new Random().NextDouble();
        return values.First(x => (rnd -= x.Probability) < 0);
    }
}