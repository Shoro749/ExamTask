using System.ComponentModel.DataAnnotations;

namespace ExamTask.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(64)]
    public string Title { get; set; }

    [Required]
    [StringLength(32)]
    public string Author { get; set; }

    [Required]
    [StringLength(32)]
    public string Publisher { get; set; }

    [Required]
    public int PageCount { get; set; }

    [Required]
    [StringLength(32)]
    public string Genre { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    public int CostPrice { get; set; }

    [Required]
    public int SellingPrice { get; set; }

    [Required]
    public bool IsContinuation { get; set; } 
}
