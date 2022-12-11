using System.ComponentModel.DataAnnotations;

namespace ZooManage.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string? AnimalName { get; set; }
        public string? Species { get; set; }
        public string? AnimalNickName { get; set; }

        public int VetId { get; set; }
        public Veterinary? Veterinary { get; set; }
        public List<Veterinary> Veterinaries { get; set; } = new List<Veterinary>();    

    }
}
