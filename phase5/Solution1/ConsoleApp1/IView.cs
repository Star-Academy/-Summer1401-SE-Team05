namespace ConsoleApp1;

public interface IView
{
    public string ReadLine();

    public void WriteLine(string toWrite);

    public void writeList(IEnumerable<string> toWrite);

    public string PromptUserToEnterInfoAndReturn(string prompt);
    
    
}