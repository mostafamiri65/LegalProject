﻿namespace Legal.Application.DTOs.Users
{
    public class LoginUserDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
