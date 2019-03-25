using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingTrackingSystemWebApp.ViewModels
{
    public class EditUserViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Type")]
        [Required]
        public UserType  Type  { get; set; }
    }
}