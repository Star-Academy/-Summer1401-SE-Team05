using System.Text.Json;

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
        JsonElement scoresElement = CreateJsonElementFromFile("C:\\Users\\gamer\\OneDrive\\Desktop\\C#-project\\Summer1401-SE-Team05\\GetBestStudents\\best_students\\scores.json");
        JsonElement studentsElement = CreateJsonElementFromFile("C:\\Users\\gamer\\OneDrive\\Desktop\\C#-project\\Summer1401-SE-Team05\\GetBestStudents\\best_students\\students.json");
        _studentCount = studentsElement.GetArrayLength();
        
        List<JsonElement> scores = CreateScoresList(scoresElement);
        List<Student> students = _studentListCreater.CreateStudentsList(studentsElement, _studentCount);
        students = _studentListCreater.AddStudentAverages(students, scores);
        _view.PrintList(SortStudentsByAvg(students).GetRange(0, 3));
    }

    private List<Student> SortStudentsByAvg(List<Student> students)
    {
        return students.OrderByDescending(o=>o.Avg).ToList();
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