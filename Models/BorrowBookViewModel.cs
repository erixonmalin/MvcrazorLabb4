using System.ComponentModel.DataAnnotations;

namespace MvcrazorLabb4.Models
{
    public class BorrowBookViewModel
    {
        public int BookId { get; set; }

        [Display(Name ="Kund id")]
        public int CustomerId { get; set; }
    }
}
