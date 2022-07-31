using System.Text.Json;
using DefaultNamespace;

namespace BEST_STUDENTS;

public class StudentListCreater
{
    public List<Student> CreateStudentsList(string studentData)
    {
        return JsonSerializer.Deserialize<List<Student>>(studentData);

    }

    public List<Student> AddStudentAverages(List<Student> students, List<Grade> grades)
    {
        foreach (var student in students)
        {
            List<Grade> tempScores = new List<Grade>(grades
                .Where(x => student.ScoreIsForStudent(x)));

            student.Avg = tempScores.ConvertAll(x => x.Score).Average();
        }
        return students;
    }
}