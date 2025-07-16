using System.ComponentModel.DataAnnotations;

namespace MvcProject.Models;

public class HeThongPhanPhoi
{
    [Key]
    public string MaHTPP { get; set; } //khóa chính 
    public string TenHTPP { get; set; }
    
}