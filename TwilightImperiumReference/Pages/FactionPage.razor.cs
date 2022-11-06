using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using MudBlazor;
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
    protected MudListItem? SelectedUnitListItem { get; set; }
    protected Unit? SelectedUnit { get; set; }
    protected bool IsUnitDisplayed { get; set; } = false;
    private DialogOptions DialogOptions = new() { FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
    protected override async Task OnInitializedAsync()
    {
        FactionId ??= "na";
        var factionDto = (await Http.GetFromJsonAsync<List<FactionDTO>>("data/factions.json"))?
                         .FirstOrDefault(f => f.Id == FactionId) ?? null;
        if (factionDto is not null)
            Faction = await Repository!.GetFactionByDTO(factionDto);
    }

    protected async Task GetUnitAndOpen(string unitType)
    {
        // needs units.json filled out
        if (IsUnitDisplayed)
            return;
        SelectedUnit = (await Http.GetFromJsonAsync<List<Unit>>("data/units.json"))?
                       .FirstOrDefault(u => u.UnitType == unitType);
        IsUnitDisplayed = true;
    }

    protected string GetColorString(string color) => $"color:{color}";
    protected void UnitClose() => IsUnitDisplayed = false;
}