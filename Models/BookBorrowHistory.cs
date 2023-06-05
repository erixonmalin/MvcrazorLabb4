using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcrazorLabb4.Models
{
    public class BookBorrowHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookBorrowHistoryId { get; set; }

        [Required]
        [Display(Name = "Bok")]
        public int BookId { get; set; }

        public Book? Books { get; set; }

        [Required]
        [Display(Name = "Kund id")]
        public int CustomerId { get; set; }

        public Customer? Customers { get; set; }

        [Display(Name = "Utlånad")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Returnerad")]
        public DateTime? ReturnDate { get; set; }
    }
}
