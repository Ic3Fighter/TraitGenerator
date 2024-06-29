using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using TraitGenerator.Models;

namespace TraitGenerator.Console;

public class Program
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Loading Traits Generator");

        // create principal trait
        var principalTrait = new PrincipalTrait()
        {
            Name = "Height",
            Values = new List<TraitValue>
            {
                new TraitValue(160, 0.25),
                new TraitValue(180, 0.5),
                new TraitValue(200, 0.25),
            }
        };

        var generator = new TraitsGenerator(principalTrait);
        generator.AddTrait(new ConditionalTrait
        {
            Name = "Intelligence",
            Values = new Dictionary<TraitValue, List<TraitValue>>
            {
                {
                    principalTrait.Values[0], new List<TraitValue> 
                    {
                        new TraitValue( 80, 0),
                        new TraitValue( 90, 0),
                        new TraitValue(100, 0.05),
                        new TraitValue(110, 0.075),
                        new TraitValue(120, 0.125),
                    }
                },
                {
                    principalTrait.Values[1], new List<TraitValue> 
                    {
                        new TraitValue( 80, 0.05),
                        new TraitValue( 90, 0.1),
                        new TraitValue(100, 0.15),
                        new TraitValue(110, 0.15),
                        new TraitValue(120, 0.05),
                    }
                },
                {
                    principalTrait.Values[2], new List<TraitValue> 
                    {
                        new TraitValue( 80, 0.15),
                        new TraitValue( 90, 0.05),
                        new TraitValue(100, 0.05),
                        new TraitValue(110, 0),
                        new TraitValue(120, 0),
                    }
                },
            }
        });

        generator.AddTrait(new ConditionalTrait
        {
            Name = "Strength",
            Values = new Dictionary<TraitValue, List<TraitValue>>
            {
                {
                    principalTrait.Values[0], new List<TraitValue> {
                        new TraitValue(20, 0.075),
                        new TraitValue(30, 0.075),
                        new TraitValue(40, 0.05),
                        new TraitValue(50, 0.025),
                        new TraitValue(60, 0.025),
                    }
                },
                {
                    principalTrait.Values[1], new List<TraitValue> {
                        new TraitValue(20, 0.1),
                        new TraitValue(30, 0.1),
                        new TraitValue(40, 0.1),
                        new TraitValue(50, 0.1),
                        new TraitValue(60, 0.1),
                    }
                },
                {
                    principalTrait.Values[2], new List<TraitValue> {
                        new TraitValue(20, 0.025),
                        new TraitValue(30, 0.025),
                        new TraitValue(40, 0.05),
                        new TraitValue(50, 0.075),
                        new TraitValue(60, 0.075),
                    }
                },
            }
        });

        // generate single trait set
        OneCharacterTraits(generator);
    }

    public static void OneCharacterTraits(TraitsGenerator generator)
    {
        // get one Character Trait Set
        var traits = generator.Get();
        System.Console.WriteLine($"Height (G) in [cm]:       {traits[0].Value:F2}");
        System.Console.WriteLine($"Intelligence (I) as [IQ]: {traits[1].Value:F0}");
        System.Console.WriteLine($"Strength (S) in [kg]:     {traits[2].Value:F2}");
    }
}