using Microsoft.AspNetCore.Components;
using TwilightImperiumReference.Models;
using System.Net.Http.Json;

namespace TwilightImperiumReference.Pages;
public partial class Leaders
{
    [Inject]
    protected HttpClient Http { get; set; } = new();

    [Inject]
    protected NavigationManager? Navigate { get; set; }

    public List<Leader>? AllLeaders { get; set; }

    protected override async Task OnInitializedAsync()
    {
        AllLeaders = await Http.GetFromJsonAsync<List<Leader>>("data/leaders.json");
    }

    protected void NavigateToFactionPage(string factionId)
    {
        Navigate!.NavigateTo($"/factions/{factionId}");
    }
}