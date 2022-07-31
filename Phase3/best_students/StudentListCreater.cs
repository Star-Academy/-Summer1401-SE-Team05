using System.Text.Json;
using DefaultNamespace;

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