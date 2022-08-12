using SampleLibrary;

namespace ConsoleApp1;

public class ConsoleController
{
    private IView _readerWriter;
    private FileReader _fileReader;
    private InvertedIndex _invertedIndex;
    private DocumentChecker _documentChecker;

    public ConsoleController(IView readerWriter, InvertedIndex invertedIndex, DocumentChecker documentChecker)
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
    
    public void Run()
    {
        Initialize();
        var query = GetQueryFromUser();
        var validDocuments = 
            _documentChecker.GetValidDocuments(new ContainerBuilder(query).GetContainer());
        _readerWriter.WriteList(validDocuments);
    }

}