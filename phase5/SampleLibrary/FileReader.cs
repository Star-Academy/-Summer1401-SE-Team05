namespace SampleLibrary;

public class FileReader
{
    private readonly String _path = "C:\\Users\\gamer\\OneDrive\\Desktop\\phase 5\\Summer1401-SE-Team05\\phase5\\SampleLibrary.Test\\testResources";
    public List<string?> _fileNames = new ();
    public String getFileContent(string path)
    {
        string content;
        using (StreamReader r = new StreamReader(path))
        {
            content = r.ReadToEnd();
        }

        return content;
    }
    
    public Dictionary<string, string> ReadFiles()
    {
        Dictionary<string, string> fileNameToContent = new Dictionary<string, string>();
        foreach (string file in Directory.GetFiles(_path, "*.txt"))
        {
            string content = File.ReadAllText(file).ToUpper();
            string filename = Path.GetFileName(file);
            fileNameToContent.Add(filename, content);
            _fileNames.Add(filename);
        }
        return fileNameToContent;
    }

    public List<string?> GetFileNames(){
        return _fileNames;
    }
}