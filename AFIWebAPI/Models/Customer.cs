using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AFIWebAPI.Models
{
    public partial class Customer
    {
        [Key]
        [JsonIgnore]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Reference number is required")]
        [RegularExpression(@"[A-Z]{2}-\d{6}", ErrorMessage = "The Reference number must be 2 capitalised letters followed by a hyphen and then 6 numeric numbers")]
        public string RefNo { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        [Required(AllowEmptyStrings = true)]
        public string Email { get; set; }
    }
}
