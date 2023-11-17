using System.ComponentModel.DataAnnotations;

namespace webapi.Models.DTO {
    public class AccessTokenDTO {
        [Required]
        public string AccessToken { get; set; }
    }
}