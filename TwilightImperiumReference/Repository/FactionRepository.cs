using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Repository;

public class FactionRepository : IFactionRepository
{
    private readonly HttpClient _client;
    private readonly IPromissoryNoteRepository _pNoteRepo;
    private readonly ITechnologyRepository _techRepo;

    public FactionRepository(HttpClient client, IPromissoryNoteRepository pNoteRepo, ITechnologyRepository techRepo)
    {
        _client = client;
        _pNoteRepo = pNoteRepo;
        _techRepo = techRepo;
    }

    public async Task<Faction> GetFactionByDTO(FactionDTO dto)
    {
        var startingTech = new List<Technology>();
        foreach (string name in dto.StartingTechnology ?? new())
        {
            var tech = await _techRepo.GetTechnology(name);
            startingTech.Add(tech);
        }
        var pNotes = new List<PromissoryNote>();
        foreach (string fpn in dto.FactionPromissoryNotes)
        {
            var pNote = await _pNoteRepo.GetPromissoryNote(fpn, dto.Id);
            pNotes.Add(pNote);
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
            StartingTechnology = startingTech,
        };
        return faction;
    }
}