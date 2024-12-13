using System;
using CriptoLesson.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using CriptoLesson.Models.ViewModels;

namespace CriptoLesson.Controllers;

public class AccountController : Controller
{
    //UserManager
    //SingManager
    //RoleManager

    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if (!ModelState.IsValid)
            return View(registerVM);

        AppUser appUser = new AppUser
        {
            UserName = registerVM.Email,
            Email = registerVM.Email,
            City = "Baku",
            Picture = "default.jpeg"
        };

        var result = await _userManager.CreateAsync(appUser, registerVM.Password);

        if (result.Succeeded)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var confirmLink = Url.Action(action: "ConfirmEmail", controller: "Home", new { email = appUser.Email, token = token }, Request.Scheme);

            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("hesenovfermayil765@gmail.com", "zrjj oykh nisz zxrs");
            smtp.EnableSsl = true;

            MailMessage mail = new MailMessage
            {
                Subject = "Confirm Your Email",
                Body = $@"
    <html>
        <head>
            <style>
                body {{
                    font-family: 'Arial', sans-serif;
                    background-color: #f4f7fc;
                    margin: 0;
                    padding: 0;
                }}
                .email-container {{
                    max-width: 600px;
                    margin: 0 auto;
                    padding: 20px;
                    background-color: #fff;
                    border-radius: 8px;
                    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
                    text-align: center;
                }}
                h1 {{
                    color: #333;
                    font-size: 24px;
                    margin-bottom: 20px;
                }}
                p {{
                    color: #555;
                    font-size: 16px;
                    line-height: 1.5;
                }}
                .button {{
                    display: inline-block;
                    padding: 12px 20px;
                    margin-top: 20px;
                    background-color: #007bff;
                    color: #fff;
                    font-size: 16px;
                    font-weight: bold;
                    text-decoration: none;
                    border-radius: 5px;
                    transition: background-color 0.3s ease;
                }}
                .button:hover {{
                    background-color: #0056b3;
                }}
            </style>
        </head>
        <body>
            <div class='email-container'>
                <h1>Welcome to CriptoCipher!</h1>
                <p>Thank you for registering with us. To complete your registration and verify your email address, please click the button below:</p>
                <a href='{confirmLink}' class='button' onclick='return confirmVerification()'>Confirm Email</a>
                <p>If you did not sign up for this account, please ignore this email.</p>
            </div>
            <script>
                function confirmVerification() {{
                    return confirm('Are you sure you want to confirm your email address and complete the registration?');
                }}
            </script>
        </body>
    </html>",
                IsBodyHtml = true,
                From = new MailAddress("hesenovfermayil765@gmail.com"),
            };
            mail.To.Add(appUser.Email);

            smtp.Send(mail);


            //await _userManager.AddToRoleAsync(appUser,"User"); rolu istesek burada veririk

            return RedirectToAction("Login");
        }

        else
            foreach (var item in result.Errors)
                ModelState.AddModelError("All", item.Description);

        return View(registerVM);
    }
    //---------------------------------------------------------------------

    public IActionResult AccessDenied()
    {
        return View();
    }







    //---------------------------------------------------------------------
    [HttpGet]
    public IActionResult Login(string? ReturnUrl = null)
    {
        ViewBag.ReturnUrl = ReturnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM, string? ReturnUrl = null)
    {
        if (!ModelState.IsValid)
            return View(loginVM);

        var user = await _userManager.FindByEmailAsync(loginVM.Email);

        if (user is null)
        {
            ModelState.AddModelError("All", "Userrr not found... Ooop...");
            return View(loginVM);
        }
        if (!await _userManager.IsEmailConfirmedAsync(user))
        {
            ModelState.AddModelError("All", "Please confirm your email... Ooop...");
            return View(loginVM);
        }
        //---------------------------------------------------------------------


        //var result = await _userManager.CheckPasswordAsync(user,loginVM.Password);

        //if (result ==false)
        //{
        //    ModelState.AddModelError("All", "Password is wrongg... Ooop...");
        //    return View(loginVM);
        //}

        //await _signInManager.SignInAsync(user,true);


        //-----------------------------------------------------------------------

        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, true, true);

        if (result.IsLockedOut)
        {
            ModelState.AddModelError("All", $"Your account is locked out => Count: {3 - user.AccessFailedCount}");

        }
        if (!result.Succeeded)
        {
            ModelState.AddModelError("All", $"Password is wrong");
        }

        if (result.Succeeded)
        {
            if (!string.IsNullOrEmpty(ReturnUrl))
                return Redirect(ReturnUrl);
            //if (Url.IsLocalUrl(ReturnUrl))
            //    return Redirect(ReturnUrl);

            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }
        return View(loginVM);
    }
}

