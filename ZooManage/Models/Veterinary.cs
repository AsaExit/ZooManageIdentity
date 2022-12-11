using System.ComponentModel.DataAnnotations;

namespace ZooManage.Models
{
    public class Veterinary
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? VetId { get; set; }

        public List<Animal> Animals { get; set; }=new List<Animal>();
    }
}
