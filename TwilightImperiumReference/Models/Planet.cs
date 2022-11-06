namespace TwilightImperiumReference.Models;

public class Planet
{
    public string Name { get; set; } = "";
    public int Resources { get; set; }
    public int Influence { get; set; }
    public string Lore { get; set; } = "";
    public string? FactionId { get; set; }
}
