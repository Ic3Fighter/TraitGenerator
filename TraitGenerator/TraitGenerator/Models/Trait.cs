namespace TraitGenerator.Models;

public class PrincipalTrait
{
    public string Name { get; set; }
    public List<TraitValue> Values { get; set; }
}

public class ConditionalTrait
{
    public string Name { get; set; }
    public Dictionary<TraitValue, List<TraitValue>> Values { get; set; }
}