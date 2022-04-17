using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using TwilightImperiumReference;
using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Pages;
public partial class Leaders
{
    [Inject]
    protected HttpClient Http { get; set; } = new();

    [Inject]
    protected NavigationManager? Navigate { get; set; }

    protected List<Leader>? AllLeaders { get; set; }

    protected string? SearchString { get; set; }

    protected override async Task OnInitializedAsync()
    {
        AllLeaders = await Http.GetFromJsonAsync<List<Leader>>("data/leaders.json");
    }

    protected void NavigateToFactionPage(string factionId) => Navigate!.NavigateTo($"/factions/{factionId}");
}