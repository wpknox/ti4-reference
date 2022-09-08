using System.Text.Json;
namespace TwilightImperiumReference.Models;

public class PromissoryNote
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string? Faction { get; set; }

    public PromissoryNote()
    {
        
    }

    public PromissoryNote(string name, string? factionId = null)
    {
        PromissoryNote? pNote = new();
        if (factionId is null)
        {
            // cannot find files in wwwroot with System.Text.Json... need to use the one used on Razor pages?
            // pNote = JsonSerializer.Deserialize<List<PromissoryNote>>(File.ReadAllText("data/pnotes.json"))
            //                          ?.FirstOrDefault(pn => pn.Name == name);
        }
        else
        {
            // pNote = JsonSerializer.Deserialize<List<PromissoryNote>>(File.ReadAllText("data/pnotes.json"))
            //                          ?.FirstOrDefault(pn => pn.Name == name && pn.Faction == factionId);
        }
        if (pNote is null) throw new ArgumentException($"There is no promissory note with the name: {name}", nameof(name));
        Name = pNote.Name;
        Description = pNote.Description;
        Faction = pNote.Faction;
    }
}