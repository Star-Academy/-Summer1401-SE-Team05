using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TopStudents;

public class Grade
{
    [Key]
    public int StudentNumber { get; set; }
    
    [Key]
    public string Lesson { get; set; }
    
    public float Score { get; set; }
}