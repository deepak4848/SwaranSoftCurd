using Microsoft.EntityFrameworkCore;
using SwaranSoftCurd.Models;
using System.ComponentModel.DataAnnotations;

namespace SwaranSoftCurd.Models
{
    public class State
    {
        [Key]
        public int  SId { get; set; }
        public string SName { get; set; }
    }
}
