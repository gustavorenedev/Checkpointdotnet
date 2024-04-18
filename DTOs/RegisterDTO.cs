using System.ComponentModel.DataAnnotations;

namespace checkpointdotnet.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string UserPhone { get; set; }
    }
}
