using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarksCRMApp.Model
{
    public class Customer : AuditableEntity<long>
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }


        [Display(Name = "State")]
        public int StateId { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        [MaxLength(15)]
        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]

        public string PhoneNumber { get; set; }

        public virtual IEnumerable<Note> Notes { get; set; }

    }
}
