namespace TwilightImperiumReference.Models;

// will need to update JSON file for Planets and Tech
public class Faction
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Icon { get; set; } = "";

    public List<string>? StartingTechnology { get; set; }
    //public List<Technology>? StartingTechnology { get; set; }
    public List<StartingUnit> StartingUnits { get; set; } = new();
    //public List<Planet> HomePlanets { get; set; } = new();
    public List<string> HomePlanets { get; set; } = new();
    public int Commodities { get; set; }
    public List<FactionAbility>? FactionAbilities { get; set; }
    public List<FactionTechnology>? FactionTechnology { get; set; }
    public List<FactionUnit>? FactionUnits { get; set; }
    public PromissoryNote FactionPromissoryNote { get; set; } = new();
    public Flagship Flagship { get; set; } = new();
    public Mech Mech { get; set; } = new();
    public List<Leader> Leaders { get; set; } = new();
    public string Lore { get; set; } = "";
}

public class FactionAbility
{
    public string Name { get; set; } = "";
    public string Ability { get; set; } = "";
}