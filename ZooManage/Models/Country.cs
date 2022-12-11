using System.ComponentModel.DataAnnotations;

namespace ZooManage.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }// Key


        [Required]
        [MaxLength(80)]
        public string? CountryName{ get; set; }
    }
}
