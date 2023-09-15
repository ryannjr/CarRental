using System.ComponentModel.DataAnnotations;

namespace webapi.Models.DTO {
    public class UserRegisterDTO {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MinLength(2, ErrorMessage = "First name must be longer than 2 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MinLength(2, ErrorMessage = "Last name must be longer than 2 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match" )]
        public string ConfirmPassword { get; set; }

        public UserRegisterDTO(Guid id, string firstName, string lastName, string email, string password, string confirmPassword) {
            this.Id = id;   
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.ConfirmPassword = confirmPassword;
        }

    }
}
