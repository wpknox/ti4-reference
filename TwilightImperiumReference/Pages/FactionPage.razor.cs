using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using TwilightImperiumReference.Models;
using TwilightImperiumReference.Repository;

namespace TwilightImperiumReference.Pages;

public partial class FactionPage
{
    [Parameter]
    public string? FactionId { get; set; }
    [Inject]
    protected HttpClient Http { get; set; } = new();
    [Inject]
    protected IFactionRepository? Repository { get; set; }

    protected Faction? Faction { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        FactionId = FactionId ?? "na";
        var factionDto = (await Http.GetFromJsonAsync<List<FactionDTO>>("data/factions.json"))?
                         .FirstOrDefault(f => f.Id == FactionId) ?? null;
        if (factionDto is not null)
            Faction = await Repository!.GetFactionByDTO(factionDto);
    }
}