namespace TwilightImperiumReference;

public static class ListExtensions
{
    public static string Join(this List<string> list, string delimiter = ", ")
    {
        return string.Join(delimiter, list ?? new List<string>());
    }
}