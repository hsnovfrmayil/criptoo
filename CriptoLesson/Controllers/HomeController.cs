using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CriptoLesson.Models;
using CriptoLesson.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CriptoLesson.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public HomeController(ILogger<HomeController> logger, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var algorithms = new List<string>
    {
        "Vigenere", "Playfair", "AES", "DES", "SM4",
        "Serpent", "Feal", "DSA", "Elgamal", "RSA",
        "Polybius", "Blowfish"
    };

        ViewBag.Algorithms = algorithms;
        return View();
    }

    public async Task<IActionResult> Helper()
    {
        return View();
    }

    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmail(string email, string token)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (result.Succeeded)
            return RedirectToAction(actionName: "Login", controllerName: "Account");

        return View("error");
    }

    [AllowAnonymous]
    public IActionResult Privacy()
    {
        return View();
    }


    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(controllerName: "Account", actionName: "Login");

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Learn(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }


    public async Task<IActionResult> Calculating()
    {
        return View();
    }
}

