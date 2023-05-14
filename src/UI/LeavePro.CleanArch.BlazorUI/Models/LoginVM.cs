﻿using System.ComponentModel.DataAnnotations;

namespace LeavePro.CleanArch.BlazorUI.Models;

public class LoginVM
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}