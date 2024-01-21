using System.ComponentModel.DataAnnotations;

namespace DIYCraftsAndProjectsMVC.Models.BLModel
{
    public class Account
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public int CountryId { get; set; }

        public int TypeId { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string Password { get; set; } = null!;
    }
}
