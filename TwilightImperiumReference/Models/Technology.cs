namespace TwilightImperiumReference.Models;

public class Technology
{
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public string Color { get; set; } = "";
    public List<string>? Prerequisities { get; set; }

    public Technology()
    {
        
    }
}

public class FactionTechnology : Technology
{
    public string FactionId { get; set; }
    public Faction? Faction { get; set; }
    public string? Ability { get; set; }

    public FactionTechnology()
    {
        FactionId = "";
    }
}