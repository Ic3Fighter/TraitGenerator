using TraitGenerator.Models;

namespace TraitGenerator;

internal static class WeightedRandomizer
{
    public static TraitValue Next(List<TraitValue> values)
    {
        // take a random number between 0 and 1
        var rnd = new Random().NextDouble();
        // normalize to values total probability
        rnd *= values.Sum(x => x.Probability);
        // take the first to break 0-line
        return values.First(x => (rnd -= x.Probability) <= 0);
    }
}