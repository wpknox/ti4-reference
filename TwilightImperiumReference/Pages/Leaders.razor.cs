using System.Net.Http.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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

    protected List<string> SortingOptions { get; set; } = new();

    protected string? SearchString { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _allLeaders = await Http.GetFromJsonAsync<List<Leader>>("data/leaders.json") ?? new();
        DisplayedLeaders = new(_allLeaders);
    }

    protected void NavigateToFactionPage(string factionId) => Navigate!.NavigateTo($"/factions/{factionId}");

    protected async Task SearchLeaders(KeyboardEventArgs e)
    {
        if (e.Key is "Enter" or "NumpadEnter")
        {
            await Task.Run(FilterLeaders);
        }
    }

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
    protected void SortLeaders(IEnumerable<string> list)
    {
        SortingOptions = list.ToList();
        DisplayedLeaders = SortingOptions.FirstOrDefault() switch
        {
            "Faction" => DisplayedLeaders.OrderBy(leader => leader.Faction).ToList(),
            "A-Z" => DisplayedLeaders.OrderBy(leader => leader.Name).ToList(),
            "Z-A" => DisplayedLeaders.OrderByDescending(leader => leader.Name).ToList(),
            _ => DisplayedLeaders.OrderBy(leader => leader.Faction).ToList(),
        };
    }

    protected void Reset()
    {
        DisplayedLeaders = new(_allLeaders);
        SearchString = null;
        SortingOptions.Clear();
    }

}