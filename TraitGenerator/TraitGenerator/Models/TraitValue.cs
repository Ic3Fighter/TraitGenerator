namespace TraitGenerator.Models;

public class TraitValue
{
    public double Value { get; set; }
    public double Probability { get; set; }

    public TraitValue(double value, double probability)
    {
        Value = value;
        Probability = probability;
    }
}