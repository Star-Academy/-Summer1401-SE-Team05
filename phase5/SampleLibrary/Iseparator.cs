namespace SampleLibrary;

public interface ISeparator
{
    public List<string> Words { set; get; }
    public List<string> Separate(List<string> toSeparate);

}