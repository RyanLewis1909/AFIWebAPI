using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFIWebAPI.ViewModels
{
    public class CustomerViewModel
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string RefNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
