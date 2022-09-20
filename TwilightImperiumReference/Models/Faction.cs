namespace TwilightImperiumReference.Models;

public class Faction
{
    // use this on the detailed page.. use DTO on list page...
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Icon { get; set; } = "";
    public List<Technology>? StartingTechnology { get; set; }
    public List<StartingUnit> StartingUnits { get; set; } = new();
    public List<Planet> HomePlanets { get; set; } = new();
    public int Commodities { get; set; }
    public List<FactionAbility>? FactionAbilities { get; set; }
    public List<FactionTechnology>? FactionTechnology { get; set; }
    public List<FactionUnit>? FactionUnits { get; set; }
    public List<PromissoryNote> FactionPromissoryNotes { get; set; } = new();
    public Flagship Flagship { get; set; } = new();
    public Mech Mech { get; set; } = new();
    public List<Leader> Leaders { get; set; } = new();
    public string Lore { get; set; } = "";

    public Faction()
    {

    }
    
}

public class FactionDTO
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Icon { get; set; } = "";
    public List<StartingUnit> StartingUnits { get; set; } = new();
    public int Commodities { get; set; }
    public List<FactionAbility>? FactionAbilities { get; set; }
    public List<FactionTechnology>? FactionTechnology { get; set; }
    public List<FactionUnit>? FactionUnits { get; set; }
    public Flagship Flagship { get; set; } = new();
    public Mech Mech { get; set; } = new();
    public List<Leader> Leaders { get; set; } = new(); // will be string list when leaders json is made...
    public List<string> FactionPromissoryNotes { get; set; } = new();
    public List<string> HomePlanets { get; set; } = new();
    public List<string>? StartingTechnology { get; set; }
    public string Lore { get; set; } = "";
}


public class FactionAbility
{
    public string Name { get; set; } = "";
    public string Ability { get; set; } = "";
}