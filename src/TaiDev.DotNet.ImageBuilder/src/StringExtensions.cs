
namespace TaiDev.DotNet.ImageBuilder;

internal static class StringExtensions
{
    /// <summary>
    /// Compare two strings and return the index of the first difference.  Returns -1 if the strings are equal.
    /// </summary>
    public static int DiffersAtIndex(this string s1, string s2)
    {
        int index = 0;
        int min = Math.Min(s1.Length, s2.Length);
        while (index < min && s1[index] == s2[index])
        {
            index++;
        }

        return (index == min && s1.Length == s2.Length) ? -1 : index;
    }

    public static string TrimEnd(this string source, string trimString)
    {
        if (string.IsNullOrEmpty(trimString))
            return source;

        while (source.EndsWith(trimString))
        {
            source = source.Substring(0, source.Length - trimString.Length);
        }

        return source;
    }
}

