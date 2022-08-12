namespace SampleLibrary;

public class WordContainer
{
    public List<string> PlusWords { get; }
    public List<string> MinusWords { get; }
    public List<string> NormalWords { get; }

    public WordContainer(List<string> normalWords, List<string> plusWords, List<string> minusWords)
    {
        NormalWords = normalWords;
        PlusWords = plusWords;
        MinusWords = minusWords;
    }

    public WordContainer(List<ISeparator> separators)
    {
        PlusWords = separators[0].Words;
        MinusWords = separators[1].Words;
        NormalWords = separators[2].Words;
    }
    
}