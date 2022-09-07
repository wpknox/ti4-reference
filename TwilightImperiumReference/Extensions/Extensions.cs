namespace TwilightImperiumReference;

public static class ListExtensions
{
    public static string Join<T>(this List<T>? list, string delimiter = ", ") =>
        string.Join(delimiter, list ?? new List<T>());
}