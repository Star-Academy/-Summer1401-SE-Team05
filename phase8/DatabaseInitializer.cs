using System.Text.Json;

namespace TopStudents;

public class DatabaseInitializer
{

    public void Run()
    {
        
        var scoresList = GetListFromFile<Grade>("scores.json");
        var studentsList = GetListFromFile<Student>("students.json");
        
        addStudentsAndScoresToDatabase(studentsList, scoresList);
    }

    
    private void addStudentAverages(PeopleContext context)
    {
        foreach (var student in context.Students.ToList())
            {
                student.Avg = context.Grades.Where(x => x.StudentNumber == student.StudentNumber)
                    .Select(x => x.Score).Average();
            }
    }
    
    private void addStudentsAndScoresToDatabase(IEnumerable<Student> studentsToAdd, IEnumerable<Grade> gradesToAdd)
    {
        using (var context = new PeopleContext())
        {
            context.Grades.AddRange(gradesToAdd);
            context.Students.AddRange(studentsToAdd);
            addStudentAverages(context);
            context.SaveChanges();
        }

    }

    private List<T>? GetListFromFile<T> (string fileName)
    {
        var path = getFilePathInResources(fileName);
        var data = getDataAtPath(path);
        return createList<T>(data);
    }

    private List<T>? createList<T> (string fileData)
    {
        return JsonSerializer.Deserialize<List<T>>(fileData);
    }

    
    private string getDataAtPath(string path)
    {
        var r = new StreamReader(path);
        return r.ReadToEnd();
    }
    
    private string getFilePathInResources(string fileName)
    {
        return Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
            "Resources",
            fileName);
    }

}