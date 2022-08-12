namespace ConsoleApp1;

public class ReaderWriter : IView
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public void WriteLine(string toWrite)
    {
        Console.WriteLine(toWrite);
    }

    public void writeList(IEnumerable<string> toWrite)
    {
        foreach (var str in toWrite)
        {
            WriteLine(str);
        }
    }

    public string PromptUserToEnterInfoAndReturn(String prompt)
    {
        WriteLine(prompt);
        return ReadLine();
    }
    
}