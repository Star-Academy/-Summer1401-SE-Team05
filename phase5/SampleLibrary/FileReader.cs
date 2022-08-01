namespace SampleLibrary;

public class FileReader
{
    private readonly String path = "Resources";
    public List<String> fileNames = new ();
    public String getFileContent(string path)
    {
        string content;
        using (StreamReader r = new StreamReader(path))
        {
            content = r.ReadToEnd();
        }

        return content;
    }
    
    public Dictionary<String, String> readFiles()
    {
        return default;
    }

    public List<string> getFileNames(){
        return default;
    }
}