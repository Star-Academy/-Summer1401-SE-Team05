using System.ComponentModel.DataAnnotations;

namespace TopStudents;

public class Student
{
    [Key]
    public int StudentNumber { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public float Avg { get; set; }
    
    public override string ToString()
    {
        return $"{FirstName} {LastName}: \n {Avg}";
    }
}