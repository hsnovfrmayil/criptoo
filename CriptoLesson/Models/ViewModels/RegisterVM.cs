using System;
using System.ComponentModel.DataAnnotations;

namespace CriptoLesson.Models.ViewModels;

public class RegisterVM
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirimPassword { get; set; }

}
