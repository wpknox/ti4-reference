using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Repository;

public class FactionRepository : IFactionRepository
{
    private readonly HttpClient _client;
    private readonly IPromissoryNoteRepository _pNoteRepo;

    public FactionRepository(HttpClient client, IPromissoryNoteRepository pNoteRepo)
    {
        _client = client;
        _pNoteRepo = pNoteRepo;
    }

    public async Task<Faction> GetFactionByDTO(FactionDTO dto)
    {
        //StartingTechnology = dto.StartingTechnology?.Select(st => new Technology(st))
        //                                            .ToList() ?? new();
        List<PromissoryNote> pNotes = new();
        foreach (string fpn in dto.FactionPromissoryNotes)
        {
            var x = await _pNoteRepo.GetPromissoryNote(fpn, dto.Id);
            pNotes.Add(x);
        }
        var faction = new Faction
        {
            Id = dto.Id,
            Name = dto.Name,
            Icon = dto.Icon,
            StartingUnits = dto.StartingUnits,
            Commodities = dto.Commodities,
            FactionAbilities = dto.FactionAbilities,
            FactionTechnology = dto.FactionTechnology,
            FactionUnits = dto.FactionUnits,
            Flagship = dto.Flagship,
            Mech = dto.Mech,
            Leaders = dto.Leaders,
            Lore = dto.Lore,
            FactionPromissoryNotes = pNotes,

        };
        return faction;
    }
}