using System.ComponentModel.DataAnnotations;

namespace ZooManage.Models
{
    public class Continent
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }


    }
}
