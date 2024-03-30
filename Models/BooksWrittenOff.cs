using System.ComponentModel.DataAnnotations;

namespace ExamTask.Models;

public class BooksWrittenOff
{
    [Key]
    public int Id { get; set; }
    [Required]
    public Book book { get; set; }
    [Required]
    [StringLength(128)]
    public string Reason { get; set; }
}
