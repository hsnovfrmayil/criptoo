using System;
using Microsoft.AspNetCore.Identity;

namespace CriptoLesson.Models.Entities;

public class AppUser :IdentityUser
{
    public string City { get; set; }

    public string Picture { get; set; }

    public DateTime DateOfBirth { get; set; }
}

