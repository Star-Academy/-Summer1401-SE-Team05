using System.Text.RegularExpressions;

namespace SampleLibrary;

public class NormalWordSeparator : ISeparator
{
    public List<string> Words { get; set; } = new();
    public List<string> Separate(List<string> toSeparate)
    {
        Words = Words.Concat(toSeparate.Where(x => Regex.IsMatch(x, "\\w+"))).ToList();

        return toSeparate.Where(x => !Words.Contains(x)).ToList();
    }
}