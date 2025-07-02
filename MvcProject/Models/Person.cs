namespace MvcProject.Models;

public class Person
{
    public required string PersonId { get; set; }
    public required string FullName { get; set; }
    public string? Address { get; set; }
}