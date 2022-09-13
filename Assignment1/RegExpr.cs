namespace Assignment1;
using System.Text.RegularExpressions;
using System.Diagnostics;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        string pattern = @"[\w]+";

        foreach (var line in lines)
        {
            MatchCollection matches = Regex.Matches(line, pattern);
            foreach(Match match in matches)
            {
                yield return match.ToString();
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
    {
        string pattern = @"((?<width>\d+)x(?<height>\d+))";
        
        foreach (var resolution in resolutions)
        {
            MatchCollection matches = Regex.Matches(resolution, pattern);
            foreach (Match match in matches)
            {
                var width = Int32.Parse(match.Groups["width"].Value);
                var height = Int32.Parse(match.Groups["height"].Value);
                yield return (width, height);
            }  
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        string pattern = $@"<{tag}.*?>(?<innerText>[\s\S]*?)<\/{tag}>";
        string toRemove = @"<[^>]*>";
        MatchCollection matches = Regex.Matches(html, pattern);
        foreach (Match match in matches)
        {
            var value = match.Groups["innerText"].Value;
            var innerText = Regex.Replace(value, toRemove, String.Empty);
            yield return innerText;
        }
    }

    public static IEnumerable<(Uri, string)> Urls(string html)
    {
        //string pattern = @"<a\s+href=""(?<url>https?:\/\/""*)""(?:\stitle=""(?<title>.*?)"")?>(?<inner>.*?)<\/a>";
        string pattern = @"href=""(?<url>.*?)"".*?(?:(?:title=""(?<title>.*?)"")|(?:>(?<innerText>.*?)<\/a>))";

        MatchCollection matches = Regex.Matches(html, pattern);
        foreach(Match match in matches)
        {
            var title = match.Groups["title"].Value.Equals("") ? match.Groups["innerText"].Value : match.Groups["title"].Value;
            yield return (new Uri(match.Groups["url"].Value), title);
        }
    }
}