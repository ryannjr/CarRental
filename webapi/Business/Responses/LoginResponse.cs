using System;
using webapi.Models.Entities;

namespace webapi.Business.Responses
{
    public class LoginResponse
    {
        public User user { get; set; }
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}
