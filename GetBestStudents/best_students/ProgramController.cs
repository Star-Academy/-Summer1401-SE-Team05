using System.Text.Json;

namespace BEST_STUDENTS;

class ProgramController
{
    private int _n;
    public void Run()
    {
        JsonElement root1 = CreateRoot1();
        //Console.WriteLine(root1);
        JsonElement root2 = CreateRoot2();
        this._n = root2.GetArrayLength();
        List<Student> students = new List<Student>();
        List<JsonElement> scores = new List<JsonElement>();
        FillScoresList(scores, root1);
        FillStudentsList(students, scores, root2);
        students = SortStudentsByAvg(students);
        WriteOutput(students);
    }

    private void WriteOutput(List<Student> students)
    {
        for(int i = 0; i < 3; i++) {
            Console.Write(students[i].FirstName + " ");
            Console.WriteLine(students[i].LastName);
            Console.WriteLine(students[i].Avg);
            Console.WriteLine();
        }
    }

    private List<Student> SortStudentsByAvg(List<Student> students)
    {
        return students.OrderByDescending(o=>o.Avg).ToList();
    }

    private void FillStudentsList(List<Student> students, List<JsonElement> scores, JsonElement root2)
    {
        for(int i = 0; i < _n; i++)
        {
            Student student = new Student(root2[i].GetProperty("StudentNumber").GetInt32(),
                root2[i].GetProperty("FirstName").GetString(),
                root2[i].GetProperty("LastName").GetString());
            
            List<JsonElement> tempScores = new List<JsonElement>(scores.Where(x => x.GetProperty("StudentNumber").GetInt32() == i + 1));

            student.Avg = tempScores.ConvertAll(x => x.GetProperty("Score").GetDouble()).Average();
            
            students.Add(student);
        }
    }

    private void FillScoresList(List<JsonElement> scores, JsonElement root1)
    {
        for(int i = 0; i < root1.GetArrayLength(); i ++)
        {
            scores.Add(root1[i]);
        }
    }

    private JsonElement CreateRoot1()
    {
        string scoresData;
        using (StreamReader r = new StreamReader("C:\\Users\\moham\\Desktop\\Summer1401-SE-Team05\\GetBestStudents\\best_students\\scores.json"))
            {
                scoresData = r.ReadToEnd();
            }
        JsonDocument doc1 = JsonDocument.Parse(scoresData);
        Console.WriteLine(doc1);
        return doc1.RootElement;
    }
    private JsonElement CreateRoot2()
    {
        string studentsData;
        using (StreamReader r = new StreamReader("C:\\Users\\moham\\Desktop\\Summer1401-SE-Team05\\GetBestStudents\\best_students\\students.json"))
            {
                studentsData = r.ReadToEnd();
            }
        
        
        JsonDocument doc2 = JsonDocument.Parse(studentsData);
        return doc2.RootElement;
    }
}