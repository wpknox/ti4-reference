using System.Net.Http.Json;
using TwilightImperiumReference.Models;
using TwilightImperiumReference.Shared;

namespace TwilightImperiumReference.Repository;

public class TechnologyRepository : ITechnologyRepository
{
    private readonly HttpClient _client;

    public TechnologyRepository(HttpClient client)
    {
        _client = client;
    }

    public async Task<Technology> GetTechnology(string name)
    {
        var tech = (await _client.GetFromJsonAsync<List<Technology>>("data/technology.json"))
                                ?.FirstOrDefault(t => t.Name == name);
        if (tech is null)
            throw new ArgumentException($"There is no technology with the name of {name}", nameof(name));
        return tech;
    }

    public async Task<FactionTechnology> GetFactionTechnology(string techName, string factionId)
    {
        var tech = (await _client.GetFromJsonAsync<List<FactionTechnology>>("data/technology.json"))
                                ?.FirstOrDefault(t => t.Name == techName && t.FactionId == factionId);
        if (tech is null)
        {
            if (FactionMap.Factions.TryGetValue(factionId, out string? factionName))
                throw new ArgumentException($"There is no technology with the name of {techName} for the faction {factionName}", nameof(techName));
            throw new ArgumentException($"The faction you are looking for does not exist", nameof(factionId));
        }
        return tech;
    }
}