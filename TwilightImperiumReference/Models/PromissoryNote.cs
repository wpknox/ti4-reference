namespace TwilightImperiumReference.Models;

public class PromissoryNote
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string? SecondPNName { get; set; }
    public string? SecondPNDescription { get; set; }
}