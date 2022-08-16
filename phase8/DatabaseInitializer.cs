using System.Text.Json;

namespace TopStudents;

public class DatabaseInitializer
{

    public void Run()
    {
        
        var scoresList = getListFromFile<Grade>("scores.json");
        var studentsList = getListFromFile<Student>("students.json");
        
        addMembersAndSave(studentsList, scoresList);
        addStudentAverages();
    }

    
    private void addStudentAverages()
    {
        using (var context = new PeopleContext())
        {
            foreach (var student in context.Students.ToList())
            {
                student.Avg = context.Grades.Where(x => x.StudentNumber == student.StudentNumber)
                    .Select(x => x.Score).Average();
            }
            context.SaveChanges();
        }
    }
    
    private void addMembersAndSave(List<Student> studentsToAdd, List<Grade> gradesToAdd)
    {
        using (var context = new PeopleContext())
        {
            context.Grades.AddRange(gradesToAdd);
            context.Students.AddRange(studentsToAdd);
            context.SaveChanges();
        }

    }

    private List<T>? getListFromFile<T> (string fileName)
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