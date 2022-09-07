using Microsoft.AspNetCore.Components;

namespace TwilightImperiumReference.Pages;

public partial class FactionPage
{
    [Parameter]
    public string? FactionId { get; set; }

    protected override void OnInitialized()
    {
        FactionId = FactionId ?? "na";
    }
}