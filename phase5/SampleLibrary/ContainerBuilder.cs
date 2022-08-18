namespace SampleLibrary;

public class ContainerBuilder
{
    private string _query;
    
    public ContainerBuilder(string query)
    {
        _query = query;
    }

    public WordContainer GetContainer()
    {
        var words = _query.Split("//s").ToList();
        var separators = GetSeparators();

        foreach (var separator in separators)
        {
            separator.Separate(words);
        }

        return new WordContainer(separators);
    }

    private List<ISeparator> GetSeparators()
    {
        return new List<ISeparator>
        {
            new PlusWordSeparator(),
            new MinusWordSeparator(),
            new NormalWordSeparator()
        };
    }
}