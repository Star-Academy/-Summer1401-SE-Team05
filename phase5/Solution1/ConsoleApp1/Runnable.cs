namespace ConsoleApp1;

public class Runnable
{
    private ReaderWriter _readerWriter;
    private FileReader _fileReader;

    public Runnable(ReaderWriter readerWriter)
    {
        _readerWriter = readerWriter;
    }

    private void GetPathFromUser()
    {
        _readerWriter.WriteLine("please enter the path of your resources");
        var path = _readerWriter.ReadLine();
        _fileReader = new FileReader(path);
    }

    public void Run()
    {
        GetPathFromUser();
        getQueryFromUser();
    }

    private void getQueryFromUser()
    {
        
    }
}