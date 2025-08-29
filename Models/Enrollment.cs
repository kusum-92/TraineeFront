using System.Text.Json.Serialization;

namespace TraineeFront.Models
{
    public class Enrollment
    {
        
            public int EnrollmentId { get; set; }
            public int TraineeId { get; set; }
            public int CourseId { get; set; } // Extra fields for display only (optional if API doesn’t return them)
            //public Course? Course { get; set; }
            //public Trainee? Trainee { get; set; }
            public string? TraineeName { get; set; }
            public string? CourseName{ get; set; } } 
        }
    

