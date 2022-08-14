using System.Text.Json;

namespace TopStudents;

public class DatabaseInitializer
{

    public void run()
    {
        var scoresList = CreateScoresList(getDataAtPath(
            "C:\\Users\\gamer\\OneDrive\\Desktop\\TopStudents\\scores.json"));
        var studentsList = CreateStudentsList(getDataAtPath(
            "C:\\Users\\gamer\\OneDrive\\Desktop\\TopStudents\\students.json"));
        using (var context = new PeopleContext())
        {
            context.Grades.AddRange(scoresList);
            context.Students.AddRange(studentsList);
            context.SaveChanges();
        }

        using (var context = new PeopleContext())
        {
            foreach (var contextStudent in context.Students.ToList())
            {
                contextStudent.Avg = context.Grades.Where(x => x.StudentNumber == contextStudent.StudentNumber)
                    .Select(x => x.Score).Average();
            }
            context.SaveChanges();
        }
    }
    
    private static List<Grade> CreateScoresList(string scoreData)
    {
        return JsonSerializer.Deserialize<List<Grade>>(scoreData);
    }

    private static List<Student> CreateStudentsList(string studentData)
    {
        return JsonSerializer.Deserialize<List<Student>>(studentData);
    }

    private static string getDataAtPath(string path)
    {
        var r = new StreamReader(path);
        return r.ReadToEnd();
    }
}