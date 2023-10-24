using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CustomerProject.Application.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("CustomerId")]
        public Guid CustomerId { get; set; }


        [Required(ErrorMessage = "The PostalCode is Required")]
        [MinLength(10)]
        [MaxLength(10)]
        [DisplayName("PostalCode")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "The Street is Required")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("Street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "The StreetNumber is Required")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("StreetNumber")]
        public string StreetNumber { get; set; }

        [DisplayName("ComplementaryAddress")]
        public string ComplementaryAddress { get; set; }

        [Required(ErrorMessage = "The City is Required")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "The State is Required")]
        [MinLength(2)]
        [MaxLength(255)]
        [DisplayName("State")]
        public string State { get; set; }
    }
}
