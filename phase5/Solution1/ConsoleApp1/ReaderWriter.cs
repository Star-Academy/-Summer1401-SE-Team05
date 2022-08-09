namespace ConsoleApp1;

public class ReaderWriter
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public void WriteLine(string toWrite)
    {
        Console.WriteLine(toWrite);
    }

    public void writeList(List<string> toWrite)
    {
        foreach (var str in toWrite)
        {
            WriteLine(str);
        }
    }
}