using TraitGenerator.Models;

namespace TraitGenerator;

public class TraitsGenerator
{
    private PrincipalTrait Principal { get; }
    private List<ConditionalTrait> Conditionals { get; set; }

    public TraitsGenerator(PrincipalTrait principal)
    {
        Principal = principal;
        Conditionals = new List<ConditionalTrait>();
    }

    public void AddTrait(ConditionalTrait trait)
    {
        // prevent duplicate trait names
        if (Conditionals.Any(x => x.Name == trait.Name))
        {
            throw new ArgumentException($"Trait name {trait.Name} exists already");
        }

        // check probabilities for non-negative values
        if (trait.Values.SelectMany(x => x.Value).Any(x => x.Probability < 0))
        {
            throw new ArgumentOutOfRangeException(nameof(TraitValue.Probability), "Trait probabilities must be non-negative");
        }

        // check probability sum
        var probabilitySum = trait.Values.SelectMany(x => x.Value).Sum(x => x.Probability);
        Console.WriteLine("Probability sum " + probabilitySum);
        if (probabilitySum < .999) // TODO might include tolerance for equality check
        {
            throw new ArgumentOutOfRangeException(nameof(TraitValue.Probability),
                $"Probability sum of all conditional trait values must be 1. Currently is {probabilitySum}");
        }

        Conditionals.Add(trait);
    }

    public void RemoveTrait(string name)
    {
        Conditionals.RemoveAll(x => x.Name == name);
    }

    public List<TraitValue> Get()
    {
        // get value of Principal Trait
        var principalValue = WeightedRandomizer.Next(Principal.Values);
        var traits = new List<TraitValue> { principalValue };

        // get weighted values of conditional traits
        foreach (var conditional in Conditionals)
        {
            var values = conditional.Values.First(x => x.Key == principalValue).Value;
            traits.Add(WeightedRandomizer.Next(values));
        }

        return traits;
    }
}