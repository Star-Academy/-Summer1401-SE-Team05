namespace ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        var readerWriter = new ReaderWriter();
        new Runnable(readerWriter).Run();
    }
}