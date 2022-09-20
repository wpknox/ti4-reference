using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Repository;

public interface IFactionRepository
{
    Task<Faction> GetFactionByDTO(FactionDTO dto);
}