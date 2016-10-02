using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarksCRMApp.Model
{
    public class State : Entity<int>
    {

        [Required]
        [MaxLength(100)]
        [Display(Name = "State Name")]
        public string Name { get; set; }

        public virtual IEnumerable<Customer> Customers { get; set; }
    }
}
