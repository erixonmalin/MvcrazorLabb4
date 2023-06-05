using System.ComponentModel.DataAnnotations;

namespace MvcrazorLabb4.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        [Display(Name = "Bok")]
        public string BookName { get; set; }

        [Display(Name = "Serienummer")]
        public string SerialNumber { get; set; }

        [Display(Name = "Författare")]
        public string AuthorName { get; set; }

        [Display(Name ="Bokförlag")]
        public string Publisher { get; set; }

        public bool? IsAvailable { get; set; }

        public int bbh { get; set; }

        public int? CustomerId { get; set; }

        [Display(Name ="Författare")]
        public string? FullName { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
