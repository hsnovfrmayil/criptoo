using System;
using Microsoft.AspNetCore.Mvc;

namespace CriptoLesson.Controllers;

public class LearnController :Controller
{
	public async Task<IActionResult> RSA(string algorithmName)
	{
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> DES(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> Vigenere(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> Playfair(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> Feistel (string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> Polybius(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> Elgamal(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> Feal(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> Serpent(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> AES(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> DSA(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> Blowfish(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }

    public async Task<IActionResult> SM4(string algorithmName)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName; // Parametri ViewBag-ə ötürürük
        return View();
    }
}

