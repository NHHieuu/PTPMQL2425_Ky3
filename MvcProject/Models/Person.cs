using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcProject.Models;

public class Person
{
    [Key]
    public required string PersonId { get; set; }
    public required string FullName { get; set; }
    public string? Address { get; set; }
     public string? Email { get; set; }
}