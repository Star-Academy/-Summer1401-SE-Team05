namespace ConsoleApp1;

public class Runnable
{
    private ReaderWriter _readerWriter;

    public Runnable(ReaderWriter readerWriter)
    {
        _readerWriter = readerWriter;
    }

    public void GetPathFromUser()
    {
        _readerWriter.WriteLine("please enter the path of your resources");
        _readerWriter.ReadLine();
    }

    public void Run()
    {
        
    }
}