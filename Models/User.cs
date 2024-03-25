using System.ComponentModel.DataAnnotations;

namespace ExamTask.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(32)]
    public string Login { get; set; }

    [Required]
    [StringLength(64)]
    public string Password { get; set; }

    [Required]
    [StringLength(32)]
    public string Role { get; set; }
}
