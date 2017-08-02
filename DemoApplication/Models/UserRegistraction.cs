using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Models
{
    public class UserRegistraction
    {
        [Required(ErrorMessage="First Name is Required")]
        public string FirstName { get; set; }

         [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

         [Required(ErrorMessage = "User Name is Required")]
        public string Username { get; set; }

         [Required(ErrorMessage = "Password is Required")]
        public string  Password { get; set; }

        [Required(ErrorMessage = "Account Type is Required")]
         public int AccountTypeId { get; set; }

         [Required(ErrorMessage = "Email ID is Required")]
        public string Email { get; set; }
         [Required(ErrorMessage = "Phone Number is Required")]
         public string Phone { get; set; }
         [Required(ErrorMessage = "Address 1 is Required")]

         public string Address1 { get; set; }
         [Required]
        public string City { get; set; }
         [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }
         [Required(ErrorMessage = "Zip is Required")]
        public string  Zip { get; set; }
    }
}