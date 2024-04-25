using System;
using System.ComponentModel.DataAnnotations;

namespace SwaranSoftCurd.Models
{
    public class StudentJoin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string State { get; set; }
        public string City { get; set; }

       
        public string AboutYourself { get; set; }
        public string UploadPhoto { get; set; }

        public string SName { get; set; }
        public int CName { get; set; }

    }
}
