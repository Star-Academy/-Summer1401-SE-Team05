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
        List<Student> students = CreateStudentsList(scores, studentsElement);

        students = SortStudentsByAvg(students);
        new View().PrintList(students.GetRange(0, 3));
    }

    private void WriteOutput(List<Student> students)
    {
        for(int i = 0; i < students.Count; i++) {
            Console.Write(students[i].FirstName + " ");
            Console.WriteLine(students[i].LastName);
            Console.WriteLine(students[i].Avg);
            Console.WriteLine("");
        }
    }

    private List<Student> SortStudentsByAvg(List<Student> students)
    {
        return students.OrderByDescending(o=>o.Avg).ToList();
    }

    private List<Student> CreateStudentsList(List<JsonElement> scores, JsonElement studentRoot)
    {
        List<Student> students = new List<Student>();
        for(int i = 0; i < _studentCount; i++)
        {
            Student student = new Student(studentRoot[i].GetProperty("StudentNumber").GetInt32(),
                studentRoot[i].GetProperty("FirstName").GetString(),
                studentRoot[i].GetProperty("LastName").GetString());

            List<JsonElement> tempScores = new List<JsonElement>(scores.Where(x => x.GetProperty("StudentNumber").GetInt32() == i + 1));

            student.Avg = tempScores.ConvertAll(x => x.GetProperty("Score").GetDouble()).Average();
            
            students.Add(student);
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