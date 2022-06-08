using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using TwilightImperiumReference.Models;

namespace TwilightImperiumReference.Pages;
public partial class PromissoryNotes
{
    [Inject]
    protected HttpClient Http { get; set; } = new();
    public List<PromissoryNote>? AllNotes { get; set; }

    protected override async Task OnInitializedAsync()
    {
        AllNotes = await Http.GetFromJsonAsync<List<PromissoryNote>>("data/pnotes.json") ?? new();
    }
}