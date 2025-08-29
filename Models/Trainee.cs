using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TraineeFront.Models
{
    public record class Trainee(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("address")] string Address,
    [property: JsonPropertyName("phone")] string Phone
        );
    
        //public int Id { get; set; }
        //public string? Name { get; set; }
        //public string? Email { get; set; }
        
        //public string? Address { get; set; }
 
        //public string? Phone { get; set; }
    
}
