using System.Text.Json;
using DefaultNamespace;

namespace BEST_STUDENTS;

class ProgramController
{
    private View _view;
    private StudentListCreater _studentListCreater;
    private int _studentCount;

    public ProgramController(View view, StudentListCreater studentListCreater)
    {
        _view = view;
        _studentListCreater = studentListCreater;
    }
    public void Run()
    {
        JsonElement scoresElement = CreateJsonElementFromFile("scores.json");
        JsonElement studentsElement = CreateJsonElementFromFile("students.json");
        _studentCount = studentsElement.GetArrayLength();
        
        List<Grade> grades = CreateScoresList(scoresElement);
        List<Student> students = _studentListCreater.CreateStudentsList(studentsElement, _studentCount);
        students = _studentListCreater.AddStudentAverages(students, grades);
        _view.PrintList(SortStudentsByAvg(students).GetRange(0, 3));
    }

    private List<Student> SortStudentsByAvg(List<Student> students)
    {
        return students.OrderByDescending(o=>o.Avg).ToList();
    }

    private List<Grade> CreateScoresList(JsonElement root1)
    {
        List<Grade> grades = new List<Grade>();
        
        for(int i = 0; i < root1.GetArrayLength(); i ++)
        {
            grades.Add(new Grade(root1[i]));
        }

        return grades;
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