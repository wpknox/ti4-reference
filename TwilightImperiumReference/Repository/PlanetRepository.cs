using System.Net.Http.Json;
using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Repository;

public class PlanetRepository : IPlanetRepository
{
    private readonly HttpClient _client;
    public PlanetRepository(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Planet>> GetAllPlanets() =>
        await ReadPlanetsAsync() ?? new List<Planet>();

    public async Task<Planet?> GetPlanet(string name) =>
        (await ReadPlanetsAsync() ?? new List<Planet>()).FirstOrDefault(p => p.Name == name);
    
    public async Task<List<Planet>> GetFactionHomePlanets(string factionId)
    {
        var allPlanets = await ReadPlanetsAsync() ?? new List<Planet>();
        return allPlanets.Where(p => p.FactionId is not null && p.FactionId == factionId).ToList();
    }
    
    private async Task<List<Planet>?> ReadPlanetsAsync() => await _client.GetFromJsonAsync<List<Planet>>("data/planets.json");
}