using System.ComponentModel.DataAnnotations;

namespace webapi.Models.DTO {
    public class UserLoginDTO {

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public UserLoginDTO(string email, string password) {
            this.Email = email;
            this.Password = password;
        }
    }
}
