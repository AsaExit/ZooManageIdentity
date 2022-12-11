using Microsoft.AspNetCore.Identity;

namespace ZooManage.Models
{
    public class AppUser: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
