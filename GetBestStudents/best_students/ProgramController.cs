using System.Text.Json;

namespace BEST_STUDENTS;

class ProgramController
{
    public int n;
    public void run()
    {
        JsonElement root1 = CreateRoot1();
        //Console.WriteLine(root1);
        JsonElement root2 = CreateRoot2();
        this.n = root2.GetArrayLength();
        List<Student> students = new List<Student>();
        List<JsonElement> scores = new List<JsonElement>();
        FillscoresList(scores, root1);
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
        for(int i = 0; i < n; i++)
        {
            Student student = new Student(root2[i].GetProperty("StudentNumber").GetInt32(), root2[i].GetProperty("FirstName").GetString(), root2[i].GetProperty("LastName").GetString());
            
            List<JsonElement> TempScores = new List<JsonElement>(scores.Where(x => x.GetProperty("StudentNumber").GetInt32() == i + 1));
            
            double sum = 0;
            for(int j = 0; j < TempScores.Count; j++)
            {
                sum += TempScores[j].GetProperty("Score").GetDouble();
            }

            student.Avg = sum / ((double) TempScores.Count);
            students.Add(student);
        }
    }

    private void FillscoresList(List<JsonElement> scores, JsonElement root1)
    {
        for(int i = 0; i < root1.GetArrayLength(); i ++)
        {
            scores.Add(root1[i]);
        }
    }

    private JsonElement CreateRoot1()
    {
        string ScoresData;
        using (StreamReader r = new StreamReader("scores.json"))
            {
                ScoresData = r.ReadToEnd();
            }
        JsonDocument doc1 = JsonDocument.Parse(ScoresData);
        Console.WriteLine(doc1);
        return doc1.RootElement;
    }
    private JsonElement CreateRoot2()
    {
        string StudentsData;
        using (StreamReader r = new StreamReader("students.json"))
            {
                StudentsData = r.ReadToEnd();
            }
        
        
        JsonDocument doc2 = JsonDocument.Parse(StudentsData);
        return doc2.RootElement;
    }
}