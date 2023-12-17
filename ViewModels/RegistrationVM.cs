using System.ComponentModel.DataAnnotations;

namespace KayanIntern.ViewModels
{
    public class RegistrationVM
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
    }
}
