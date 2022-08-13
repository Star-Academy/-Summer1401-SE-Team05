namespace BEST_STUDENTS;

public class View
{
    public void PrintList<T>(IEnumerable<T> enumerable)
    {
        foreach(var item in enumerable) Console.WriteLine(item.ToString());
    }
}