using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcrazorLabb4.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        [Display(Name = "Bokens namn")]
        public string BookName { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        [Display(Name = "Serienummer")]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        [Display(Name = "Författare, Förnamn")]
        public string AuthorFName { get; set; }

        [Required]
        [StringLength(maximumLength: 70, MinimumLength = 1)]
        [Display(Name = "Författare, Efternamn")]
        public string AuthorLName { get; set; }

        [NotMapped]
        [DisplayName("Författare")]
        public string FullName => $"{AuthorFName} {AuthorLName}";

        [StringLength(maximumLength: 70, MinimumLength = 1)]
        [Display(Name ="Bokförlag")]
        public string Publisher { get; set; }

        public bool? IsBorrowed { get; set; } = false;

        public ICollection<BookBorrowHistory> BookBorrowHistories { get; set; }
    }
}
