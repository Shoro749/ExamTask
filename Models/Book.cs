using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTask.Models
{
    public class Book
    {
        public string Title { get; set; } 
        public string Author { get; set; } 
        public string Publisher { get; set; } 
        public int PageCount { get; set; } 
        public string Genre { get; set; } 
        public int Year { get; set; } 
        public decimal CostPrice { get; set; } 
        public decimal SellingPrice { get; set; } 
        public bool IsContinuation { get; set; } 
    }
}
