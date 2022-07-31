using System.Text.Json;

namespace DefaultNamespace;

public class Grade
{
    public int StudentNumber { get; set; }
    public string Lesson { get; set; }
    public double Score { get; set; }

    public Grade(int studentNumber, string lesson, double score)
    {
        Lesson = lesson;
        Score = score;
        StudentNumber = studentNumber;
    }

    public Grade(JsonElement jsonElement)
    {
        Lesson = jsonElement.GetProperty("Lesson").GetString();
        StudentNumber = jsonElement.GetProperty("StudentNumber").GetInt32();
        Score = jsonElement.GetProperty("Score").GetDouble();
    }
}