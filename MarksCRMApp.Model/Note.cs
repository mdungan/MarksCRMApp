using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarksCRMApp.Model
{
    public class Note : AuditableEntity<long>
    {


        [Required]
        public string Body { get; set; }
        [Required]
        [Display(Name = "Customer")]
        [ForeignKey("Customer")]
        public Int64 CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
