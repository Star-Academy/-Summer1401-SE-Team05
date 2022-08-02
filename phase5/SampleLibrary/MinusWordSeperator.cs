namespace SampleLibrary;

public class MinusWordSeperator : ISeparator
{
    public List<string> Words { get; set; } = new ();
    public List<string> Separate(List<string> toSeparate)
    {
        Words = Words.Concat(toSeparate.Where(x => x.StartsWith("-"))
            .Select(x => x.Substring(1))).ToList();

        return toSeparate.Where(x => !x.StartsWith("-")).ToList();
    }
}