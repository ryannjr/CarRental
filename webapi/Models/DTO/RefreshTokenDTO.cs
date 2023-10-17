using System.ComponentModel.DataAnnotations;

namespace webapi.Models.DTO {
    public class RefreshTokenDTO {
        [Required]
        public string RefreshToken { get; set; }
    }
}
