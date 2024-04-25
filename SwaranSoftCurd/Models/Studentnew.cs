using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SwaranSoftCurd.Models;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace SwaranSoftCurd.Models
{
    public class Studentnew
    {
         [Key]
        public int Id { get; set; }
    
        public string Name { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        //[Display(Name = "Mobile Number:")]
        //[Required(ErrorMessage = "Mobile Number is required.")]
        //[RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        [StringLength(250, ErrorMessage = "About Yourself must not exceed 250 characters.")]
        public string AboutYourself { get; set; }

        public string UploadPhoto { get; set; }

        public List<State> countries { get; set; }
       public List<City> tblstates { get; set; }
       

    }
}
