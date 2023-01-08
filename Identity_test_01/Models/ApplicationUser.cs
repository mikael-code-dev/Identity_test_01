using Microsoft.AspNetCore.Identity;

namespace Identity_test_01.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
