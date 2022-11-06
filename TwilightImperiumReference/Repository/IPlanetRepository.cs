using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Repository;

public interface IPlanetRepository
{
    Task<List<Planet>> GetAllPlanets();
    Task<Planet?> GetPlanet(string name);
    Task<List<Planet>> GetFactionHomePlanets(string factionId);
}