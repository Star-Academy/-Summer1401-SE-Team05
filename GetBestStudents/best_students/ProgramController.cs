using System.Text.Json;

namespace BEST_STUDENTS;

class ProgramController
{
    private int _studentCount;
    public void Run()
    {
        JsonElement scoresElement = CreateJsonElementFromFile("C:\\Users\\moham\\Desktop\\Summer1401-SE-Team05\\GetBestStudents\\best_students\\scores.json");
        JsonElement studentsElement = CreateJsonElementFromFile("C:\\Users\\moham\\Desktop\\Summer1401-SE-Team05\\GetBestStudents\\best_students\\students.json");
        _studentCount = studentsElement.GetArrayLength();
        
        List<JsonElement> scores = CreateScoresList(scoresElement);
        List<Student> students = CreateStudentsList(studentsElement);
        students = AddStudentAverages(students, scores);
        new View().PrintList(SortStudentsByAvg(students).GetRange(0, 3));
    }

    private List<Student> SortStudentsByAvg(List<Student> students)
    {
        return students.OrderByDescending(o=>o.Avg).ToList();
    }

    private List<Student> CreateStudentsList(JsonElement studentRoot)
    {
        List<Student> students = new List<Student>();
        for(int i = 0; i < _studentCount; i++)
        {
            students.Add(new Student(studentRoot[i]));
        }

        return students;
    }

    private List<Student> AddStudentAverages(List<Student> students, List<JsonElement> scores)
    {
        foreach (var student in students)
        {
            List<JsonElement> tempScores = new List<JsonElement>(scores
                .Where(x => student.ScoreIsForStudent(x)));

            student.Avg = tempScores.ConvertAll(x => x.GetProperty("Score").GetDouble()).Average();
        }
        return students;
    }

    private List<JsonElement> CreateScoresList(JsonElement root1)
    {
        List<JsonElement> scores = new List<JsonElement>();
        
        for(int i = 0; i < root1.GetArrayLength(); i ++)
        {
            scores.Add(root1[i]);
        }

        return scores;
    }

    private JsonElement CreateJsonElementFromFile(string path)
    {
        string scoresData;
        using (StreamReader r = new StreamReader(path))
        {
            scoresData = r.ReadToEnd();
        }
        JsonDocument doc1 = JsonDocument.Parse(scoresData);
        return doc1.RootElement;
    }
    
}