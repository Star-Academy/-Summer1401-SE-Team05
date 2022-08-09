namespace ConsoleApp1;

public class Runnable
{
    private ReaderWriter _readerWriter;

    public Runnable(ReaderWriter readerWriter)
    {
        _readerWriter = readerWriter;
    }

    public string GetPathFromUser()
    {
        _readerWriter.WriteLine("please enter the path of your resources");
        return _readerWriter.ReadLine();
    }

    public void Run()
    {
        
    }
}