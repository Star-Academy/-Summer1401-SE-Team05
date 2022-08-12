namespace ConsoleApp1;

public interface IView
{
    public string ReadLine();

    public void WriteLine(string toWrite);

    public void WriteList(IEnumerable<string> toWrite);

    public string PromptUserToEnterInfoAndReturn(string prompt);
    
    
}