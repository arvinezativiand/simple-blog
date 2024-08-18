namespace Codeyad.CoreLayer.Utilities;

public static class TextEditor
{
    public static string ToSlug(this string slug)
    {
        return slug.ToLower().Replace("`", "")
            .Replace("~", "")
            .Replace("!", "")
            .Replace("@", "")
            .Replace("#", "")
            .Replace("$", "")
            .Replace("%", "")
            .Replace("^", "")
            .Replace("&", "")
            .Replace("*", "")
            .Replace(")", "")
            .Replace("(", "")
            .Replace("+", "")
            .Replace("/", "")
            .Replace(@"\","")
            .Replace(">", "")
            .Replace("<", "")
            .Replace("=", "").Trim().Replace(" ", "-");

    }
}
