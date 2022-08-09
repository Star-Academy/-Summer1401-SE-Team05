using SampleLibrary;

namespace ConsoleApp1;

public class Runnable
{
    private ReaderWriter _readerWriter;
    private FileReader _fileReader;
    private InvertedIndex _invertedIndex;
    private DocumentChecker _documentChecker;

    public Runnable(ReaderWriter readerWriter, InvertedIndex invertedIndex, DocumentChecker documentChecker)
    {
        _readerWriter = readerWriter;
        _documentChecker = documentChecker;
        _invertedIndex = invertedIndex;
    }

    private void GetPathFromUser()
    {
        var path = 
            _readerWriter.PromptUserToEnterInfoAndReturn("please enter the path of your resources:");
        _fileReader = new FileReader(path);
    }

    
    private void Initialize()
    {
        GetPathFromUser();
        _invertedIndex.createIndex(_fileReader.ReadFiles());
    }

    private string GetQueryFromUser()
    {
        return _readerWriter.PromptUserToEnterInfoAndReturn("please enter your query:");
    }
    
    
    private WordContainer GetWordContainerOfQuery(string query)
    {
        var words = query.Split("//s").ToList();
        var plusWordSeparator = new PlusWordSeparator();
        var minusWordSeparator = new MinusWordSeperator();
        var normalWords = plusWordSeparator.Separate(minusWordSeparator.Separate(words));

        return new WordContainer(normalWords, plusWordSeparator.Words, minusWordSeparator.Words);
    }
    
    public void Run()
    {
        Initialize();
        var query = GetQueryFromUser();
        var container = GetWordContainerOfQuery(query);
        var validDocuments = _documentChecker.GetValidDocuments(container);
        _readerWriter.writeList(validDocuments);
    }

}