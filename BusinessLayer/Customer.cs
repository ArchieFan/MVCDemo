using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{

    public interface ICustomer
    {
        int ID { get; set; }
        string Gender { get; set; }
        string City { get; set; }
        DateTime? DateOfBirth { get; set; }
    }
    public class Customer : ICustomer
    {
        public int ID { get; set; }

        //[Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}
