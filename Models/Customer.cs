using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcrazorLabb4.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [NotMapped]
        [DisplayName("Kund")]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [StringLength(maximumLength: 50)]
        [Display(Name = "Gata")]
        public string StreetName { get; set; }

        [Display(Name = "Hus nummer")]
        public int HouseNumber { get; set; }

        [StringLength(maximumLength: 40, MinimumLength = 1)]
        [Display(Name ="Ort")]
        public string City { get; set; }

        [Display(Name = "Telefonnummer")]
        public string? PhoneNumber { get; set; }
    }
}
