namespace TwilightImperiumReference.Models;

public class Unit
{
    public string? UnitType { get; set; }
    public decimal Cost { get; set; }
    public int CombatNumber { get; set; }
    public int? Capacity { get; set; }
    public int Hits { get; set; } = 1;
    public int Movement { get; set; } = 0;
    public List<string>? Abilities { get; set; }
    public List<string>? Prerequisites { get; set; }
    public Unit? Upgrade { get; set; }
}

public class FactionUnit : Unit
{
    public string Name { get; set; } = "";
    public string? Faction { get; set; }
}

public class Flagship : Unit
{
    public string Name { get; set; } = "";
    public string? Faction { get; set; }
}

public class Mech : Unit
{
    public string? Faction { get; set; }
}

public class StartingUnit
{
    public string UnitType { get; set; } = "";
    public int Amount { get; set; }
}
