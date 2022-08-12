namespace SampleLibrary;

public class FileReader
{
    private readonly string _path;
    private List<string?> _fileNames = new ();

    public FileReader(string path)
    {
        _path = path;
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

    public IEnumerable<string?> GetFileNames(){
        return _fileNames;
    }
}