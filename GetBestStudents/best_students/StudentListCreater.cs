using System.Text.Json;

namespace BEST_STUDENTS;

public class StudentListCreater
{
    public List<Student> CreateStudentsList(JsonElement studentRoot, int studentCount)
    {
        List<Student> students = new List<Student>();
        for(int i = 0; i < studentCount; i++)
        {
            students.Add(new Student(studentRoot[i]));
        }

        return students;
    }

    public List<Student> AddStudentAverages(List<Student> students, List<JsonElement> scores)
    {
        foreach (var student in students)
        {
            List<JsonElement> tempScores = new List<JsonElement>(scores
                .Where(x => student.ScoreIsForStudent(x)));

            student.Avg = tempScores.ConvertAll(x => x.GetProperty("Score").GetDouble()).Average();
        }
        return students;
    }
}