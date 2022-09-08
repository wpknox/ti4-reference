using System.Net.Http.Json;
using System.Text.Json;
namespace TwilightImperiumReference.Models;

public class PromissoryNote
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string? Faction { get; set; }

    public PromissoryNote(string name, string? factionId = null)
    {
        PromissoryNote? pNote;
        if (factionId is null)
        {
            pNote = JsonSerializer.Deserialize<List<PromissoryNote>>("data/pnotes.json")
                                     ?.FirstOrDefault(pn => pn.Name == name);
        }
        else
        {
            pNote = JsonSerializer.Deserialize<List<PromissoryNote>>("data/pnotes.json")
                                     ?.FirstOrDefault(pn => pn.Name == name && pn.Faction == factionId);
        }
        if (pNote is null) throw new ArgumentException($"There is no promissory note with the name: {name}", nameof(name));
        Name = pNote.Name;
        Description = pNote.Description;
        Faction = pNote.Faction;
    }
}