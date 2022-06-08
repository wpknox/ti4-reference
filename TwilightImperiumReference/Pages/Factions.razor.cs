using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Pages;

public partial class Factions
{
    [Inject]
    protected HttpClient Http { get; set; } = new();

    [Inject]
    protected NavigationManager? Navigate { get; set; }
    protected List<FactionDTO>? AllFactions { get; set; }

    protected override async Task OnInitializedAsync()
    {
        AllFactions = await Http.GetFromJsonAsync<List<FactionDTO>>("data/factions.json");
    }
    protected void NavigateToFactionPage(string factionId) => Navigate!.NavigateTo($"/factions/{factionId}");
}