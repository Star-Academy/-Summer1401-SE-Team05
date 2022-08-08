namespace SampleLibrary;

public class FileReader
{
    private readonly string _path;
    public List<string?> _fileNames = new ();

    public FileReader(string path)
    {
        _path = path;
    }
    
    
    public string getFileContent(string path)
    {
        string content;
        using (var r = new StreamReader(path))
        {
            content = r.ReadToEnd();
        }

        return content;
    }
    
    public Dictionary<string, string> ReadFiles()
    {
        var fileNameToContent = new Dictionary<string, string>();
        foreach (var file in Directory.GetFiles(_path, "*.txt"))
        {
            var content = File.ReadAllText(file).ToUpper();
            var filename = Path.GetFileName(file);
            fileNameToContent.Add(filename, content);
            _fileNames.Add(filename);
        }
        return fileNameToContent;
    }

    public List<string?> GetFileNames(){
        return _fileNames;
    }
}