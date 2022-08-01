namespace SampleLibrary;

public abstract class AbstractSeparator : ISeparator
{
    public List<string> Words = new ();

    public List<string> Separate(List<string> toSeparate)
    {
        throw new NotImplementedException();
    }
}