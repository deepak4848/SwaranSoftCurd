using System.ComponentModel.DataAnnotations;

namespace SwaranSoftCurd.Models
{
    public class City
    {
        [Key]
        public int CId { get; set; }
        public int SId { get; set; }
        public string CName { get; set; }
    }
}
