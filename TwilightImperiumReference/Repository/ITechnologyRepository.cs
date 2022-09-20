using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Repository;

public interface ITechnologyRepository
{
    Task<Technology> GetTechnology(string name);
    Task<FactionTechnology> GetFactionTechnology(string name, string factionId);
}