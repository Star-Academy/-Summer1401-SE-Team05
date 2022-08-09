namespace ConsoleApp1;

public class ReaderWriter
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }

    private void WriteLine(string toWrite)
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

    public string PromptUserToEnterInfoAndReturn(String prompt)
    {
        WriteLine(prompt);
        return ReadLine();
    }
    
}