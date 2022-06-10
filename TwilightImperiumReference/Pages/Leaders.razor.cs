using System.Net.Http.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Pages;
public partial class Leaders
{
    [Inject]
    protected HttpClient Http { get; set; } = new();

    [Inject]
    protected NavigationManager? Navigate { get; set; }

    private List<Leader> _allLeaders = new();

    protected List<Leader> DisplayedLeaders { get; set; } = new();

    protected string? SearchString { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _allLeaders = await Http.GetFromJsonAsync<List<Leader>>("data/leaders.json") ?? new();
        DisplayedLeaders = new(_allLeaders);
    }

    protected void NavigateToFactionPage(string factionId) => Navigate!.NavigateTo($"/factions/{factionId}");

    protected void FilterLeaders()
    {
        if (SearchString is null or "")
        {
            Reset();
            return;
        }
        var searchString = SearchString.ToUpperInvariant();
        var regex = new Regex("[^a-zA-Z]"); // ignore "-", " ' " (apostrophes), and " " from names
        DisplayedLeaders = new(_allLeaders.Where(l => regex.Replace(l.Name, "")
                                                           .ToUpperInvariant()
                                                           .Contains(searchString)));
    }

    protected void Reset()
    {
        DisplayedLeaders = new(_allLeaders);
        SearchString = null;
    }
}