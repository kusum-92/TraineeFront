
using System.Text.Json.Serialization;
namespace TraineeFront.Models
{
    public record class Course(

        [property: JsonPropertyName("courseId")] int CourseId,
        [property: JsonPropertyName("courseName")] string CourseName,
        [property: JsonPropertyName("courseDescription")] string CourseDescription

  );  
}
