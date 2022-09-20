using System.Net.Http.Json;
using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Repository;

public class PromissoryNoteRepository : IPromissoryNoteRepository
{
    private readonly HttpClient _client;

    public PromissoryNoteRepository(HttpClient client)
    {
        _client = client;
    }

    public async Task<PromissoryNote> GetPromissoryNote(string name, string? factionId = null)
    {
        var allPNotes = (await _client.GetFromJsonAsync<List<PromissoryNote>>("data/pnotes.json"));
        if (allPNotes is null)
            throw new ArgumentNullException("pnotes.json", "Unable to find promissory notes Json file");
        var pNote = factionId is null ?
                    allPNotes.FirstOrDefault(pn => pn.Name == name) :
                    allPNotes.FirstOrDefault(pn => pn.Name == name && pn.Faction == factionId);
        if (pNote is null) throw new ArgumentException($"There is no promissory note with the name: {name}", nameof(name));
        return pNote;
    }
}