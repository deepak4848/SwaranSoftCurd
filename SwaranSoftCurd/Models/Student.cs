using Microsoft.EntityFrameworkCore;
using SwaranSoftCurd.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;


namespace SwaranSoftCurd.Models
{
    public class Student
    {
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string AboutYourself { get; set; }
        public string UploadPhoto { get; set; }
    }

   

}
