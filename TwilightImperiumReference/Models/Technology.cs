using System.Text.Json;
using TwilightImperiumReference;
using TwilightImperiumReference.Shared;

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

    // public Technology(string techName)
    // {
    //     // var tech = JsonSerializer.Deserialize<List<Technology>>("data/technology.json")
    //     //                          ?.FirstOrDefault(t => t.Name == techName);
    //     if (tech is null)
    //         throw new ArgumentException($"There is no technology with the name of {techName}", nameof(techName));
    //     Name = tech.Name;
    //     Description = tech.Description;
    //     Color = tech.Color;
    //     Prerequisities = tech.Prerequisities;
    // }
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

    // public FactionTechnology(string techName, string factionId)
    // {
    //     // var tech = JsonSerializer.Deserialize<List<FactionTechnology>>(File.ReadAllText("data/technology.json"))
    //     //                          ?.FirstOrDefault(t => t.Name == techName && t.FactionId == factionId);
    //     if (tech is null)
    //     {
    //         if (FactionMap.Factions.TryGetValue(factionId, out string? factionName))
    //             throw new ArgumentException($"There is no technology with the name of {techName} for the faction {factionName}", nameof(techName));
    //         throw new ArgumentException($"The faction you are looking for does not exist", nameof(factionId));

    //     }
    //     Name = tech.Name;
    //     Description = tech.Description;
    //     Color = tech.Color;
    //     Prerequisities = tech.Prerequisities;
    //     FactionId = tech.FactionId;
    //     Ability = tech.Ability;
    //     var faction = JsonSerializer.Deserialize<List<Faction>>(File.ReadAllText("data/factions.json"))
    //                                 !.FirstOrDefault(f => f.Id == FactionId);
    //     Faction = faction;
    // }
}