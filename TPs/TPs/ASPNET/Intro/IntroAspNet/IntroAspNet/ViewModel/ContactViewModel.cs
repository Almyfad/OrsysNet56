﻿using System.ComponentModel.DataAnnotations;

namespace IntroAspNet.ViewModel;

public class ContactViewModel
{
    [Required]
    [StringLength(20, MinimumLength = 5)]
    public string? Nom { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [MaxLength(30)]
    public string? Sujet { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Message { get; set; }
}
