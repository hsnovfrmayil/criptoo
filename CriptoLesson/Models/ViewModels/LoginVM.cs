using System;
using System.ComponentModel.DataAnnotations;

namespace CriptoLesson.Models.ViewModels;

public class LoginVM
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

}

