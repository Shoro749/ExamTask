using System.ComponentModel.DataAnnotations;

namespace ExamTask.Models;

public class ShelvedBooks
{
    [Key]
    public int id { get; set; }
    [Required]
    public Book book { get; set; }
}
