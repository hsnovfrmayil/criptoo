using CriptoLesson.Models;
using CriptoLesson.Models.CipherMethods;
using Microsoft.AspNetCore.Mvc;

public class CalculatingController : Controller
{
    // PlayfairMethods sınıfından yeni bir örnek oluşturuyoruz
    private readonly PlayfairMethods _playfairMethods = new PlayfairMethods();
    private readonly VigenereMethods _vigenereMethods = new VigenereMethods();
    private readonly FeistelMethods _feistelMethods = new FeistelMethods();
    private readonly PolybiusMethods _polybiusMethods = new();
    private readonly FealMethods _fealMethods = new();
    private readonly ElgamalMethods _elgamalMethods = new();
    private readonly AesMethods _aesMethods = new();
    private readonly DesMethods _desMethods = new();
    private readonly RsaMethods _rsaMethods = new();
    private readonly SerpentMethods _serpentMethods = new();
   


    public IActionResult Playfair(string algorithmName, string inputTextEncrypt, string inputTextDecrypt, string actionType)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName;

        string result = string.Empty;
        string resultType = string.Empty;

        if (actionType == "Encrypt" && !string.IsNullOrEmpty(inputTextEncrypt))
        {
            result = _playfairMethods.PlayfairEncrypt(inputTextEncrypt); // Encrypt
            resultType = "Encryption Result";
        }
        else if (actionType == "Decrypt" && !string.IsNullOrEmpty(inputTextDecrypt))
        {
            result = _playfairMethods.PlayfairDecrypt(inputTextDecrypt); // Decrypt
            resultType = "Decryption Result";
        }

        ViewBag.Result = result;
        ViewBag.ResultType = resultType; // Adding result type to ViewBag

        return View();
    }

    public IActionResult Vigenere(string algorithmName, string inputTextEncrypt, string inputTextDecrypt, string actionType)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName;

        string result = string.Empty;
        string resultType = string.Empty;

        if (actionType == "Encrypt" && !string.IsNullOrEmpty(inputTextEncrypt))
        {
            result = _vigenereMethods.VigenereEncrypt(inputTextEncrypt); // Encrypt
            resultType = "Encryption Result";
        }
        else if (actionType == "Decrypt" && !string.IsNullOrEmpty(inputTextDecrypt))
        {
            result = _vigenereMethods.VigenereDecrypt(inputTextDecrypt); // Decrypt
            resultType = "Decryption Result";
        }

        ViewBag.Result = result;
        ViewBag.ResultType = resultType; // Adding result type to ViewBag

        return View();
    }


    public IActionResult Feistel(string algorithmName, string inputTextEncrypt, string inputTextDecrypt, string actionType, string key)
    {
        string result = "";
        string resultType = "";

        if (actionType == "Encrypt" && !string.IsNullOrEmpty(inputTextEncrypt))
        {
            result = _feistelMethods.FeistelEncrypt(inputTextEncrypt, key);
            resultType = "Encrypted Text";
        }
        else if (actionType == "Decrypt" && !string.IsNullOrEmpty(inputTextDecrypt))
        {
            result = _feistelMethods.FeistelDecrypt(inputTextDecrypt, key);
            resultType = "Decrypted Text";
        }

        ViewBag.Result = result;
        ViewBag.ResultType = resultType;
        return View();
    }


    public IActionResult Polybius(string actionType, string inputTextEncrypt, string inputTextDecrypt)
    {
        string result = "";
        string resultType = "";

        if (actionType == "Encrypt" && !string.IsNullOrEmpty(inputTextEncrypt))
        {
            result = _polybiusMethods.PolybiusEncrypt(inputTextEncrypt);
            resultType = "Encrypted Text";
        }
        else if (actionType == "Decrypt" && !string.IsNullOrEmpty(inputTextDecrypt))
        {
            result = _polybiusMethods.PolybiusDecrypt(inputTextDecrypt);
            resultType = "Decrypted Text";
        }

        ViewBag.Result = result;
        ViewBag.ResultType = resultType;
        return View();
    }

    public IActionResult Feal(string algorithmName, string inputTextEncrypt, string inputTextDecrypt, string actionType)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName;

        string result = string.Empty;
        string resultType = string.Empty;

        if (actionType == "Encrypt" && !string.IsNullOrEmpty(inputTextEncrypt))
        {
            result = _fealMethods.FealEncrypt(inputTextEncrypt); // Encrypt
            resultType = "Encryption Result";
        }
        else if (actionType == "Decrypt" && !string.IsNullOrEmpty(inputTextDecrypt))
        {
            result = _fealMethods.FealDecrypt(inputTextDecrypt); // Decrypt
            resultType = "Decryption Result";
        }

        ViewBag.Result = result;
        ViewBag.ResultType = resultType; // Adding result type to ViewBag

        return View();
    }

    public IActionResult Elgamal(string algorithmName, string inputTextEncrypt, string inputTextDecrypt, string actionType, string key)
    {
        ViewBag.AlgorithmName = algorithmName;

        string result = string.Empty;
        string resultType = string.Empty;
        string originalText = string.Empty;
        string encryptedText = string.Empty;

        var elgamalMethods = new ElgamalMethods(); // Elgamal metodu

        if (actionType == "Encrypt" && !string.IsNullOrEmpty(inputTextEncrypt))
        {
            encryptedText = elgamalMethods.ElgamalEncrypt(inputTextEncrypt, key); // Şifrələmə
            resultType = "Encryption Result";
            result = encryptedText;
            originalText = inputTextEncrypt;
        }
        else if (actionType == "Decrypt" && !string.IsNullOrEmpty(inputTextDecrypt))
        {
            result = elgamalMethods.ElgamalDecrypt(inputTextDecrypt, key); // Deşifrələmə
            resultType = "Decryption Result";
            originalText = inputTextDecrypt;
            encryptedText = result;  // Deşifrələdikdən sonra şifrələnmiş mətn də göstərilir
        }

        // Nəticə və digər məlumatları ViewBag-də göndəririk
        ViewBag.Result = result;
        ViewBag.ResultType = resultType;
        ViewBag.OriginalText = originalText;
        ViewBag.EncryptedText = encryptedText;
        ViewBag.Key = key;

        return View();
    }


    public IActionResult Aes(string algorithmName, string inputTextEncrypt, string inputTextDecrypt, string actionType)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName;
        string result = string.Empty;
        string resultType = string.Empty;

        if (actionType == "Encrypt" && !string.IsNullOrEmpty(inputTextEncrypt))
        {
            result = _aesMethods.AesEncrypt(inputTextEncrypt); // Encrypt
            resultType = "Encryption Result";
        }
        else if (actionType == "Decrypt" && !string.IsNullOrEmpty(inputTextDecrypt))
        {
            result = _aesMethods.AesDecrypt(inputTextDecrypt); // Decrypt
            resultType = "Decryption Result";
        }

        ViewBag.Result = result;
        ViewBag.ResultType = resultType; // Adding result type to ViewBag

        return View();
    }

    public IActionResult Des(string algorithmName, string inputTextEncrypt, string inputTextDecrypt, string actionType, string key)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName;

        string result = string.Empty;
        string resultType = string.Empty;

        if (actionType == "Encrypt" && !string.IsNullOrEmpty(inputTextEncrypt) && !string.IsNullOrEmpty(key))
        {
            result = _desMethods.DesEncrypt(inputTextEncrypt, key); // Encrypt
            resultType = "Encryption Result";
        }
        else if (actionType == "Decrypt" && !string.IsNullOrEmpty(inputTextDecrypt) && !string.IsNullOrEmpty(key))
        {
            result = _desMethods.DesDecrypt(inputTextDecrypt, key); // Decrypt
            resultType = "Decryption Result";
        }

        ViewBag.Result = result;
        ViewBag.ResultType = resultType;

        return View();
    }

    public IActionResult Rsa(string inputTextEncrypt, string inputTextDecrypt, string actionType)
    {
        string result = string.Empty;
        string resultType = string.Empty;

        if (actionType == "Encrypt" && !string.IsNullOrEmpty(inputTextEncrypt))
        {
            result = _rsaMethods.RsaEncrypt(inputTextEncrypt); // Şifreleme işlemi
            resultType = "Encryption Result";
        }
        else if (actionType == "Decrypt" && !string.IsNullOrEmpty(inputTextDecrypt))
        {
            result = _rsaMethods.RsaDecrypt(inputTextDecrypt); // Deşifreleme işlemi
            resultType = "Decryption Result";
        }

        ViewBag.Result = result;
        ViewBag.ResultType = resultType; // Result türünü de ViewBag'e ekliyoruz

        return View();
    }

    public IActionResult Serpent(string algorithmName, string inputTextEncrypt, string inputTextDecrypt, string actionType)
    {
        if (string.IsNullOrEmpty(algorithmName))
        {
            return RedirectToAction("Index");
        }

        ViewBag.AlgorithmName = algorithmName;

        string result = string.Empty;
        string resultType = string.Empty;

        if (actionType == "Encrypt" && !string.IsNullOrEmpty(inputTextEncrypt))
        {
            result = _serpentMethods.SerpentEncrypt(inputTextEncrypt); // Encrypt
            resultType = "Encryption Result";
        }
        else if (actionType == "Decrypt" && !string.IsNullOrEmpty(inputTextDecrypt))
        {
            result = _serpentMethods.SerpentDecrypt(inputTextDecrypt); // Decrypt
            resultType = "Decryption Result";
        }

        ViewBag.Result = result;
        ViewBag.ResultType = resultType; // Adding result type to ViewBag

        return View();
    }



    public IActionResult SM4(string algorithmName, string inputTextEncrypt, string inputTextDecrypt, string actionType, string key)
    {
        // Açarın düzgün uzunluqda olub-olmadığını yoxlayırıq
        //if (string.IsNullOrEmpty(key) || key.Length != 16)
        //{
        //    return BadRequest("Key must be exactly 16 characters long.");
        //}

        ViewBag.AlgorithmName = algorithmName;

        string result = string.Empty;
        string resultType = string.Empty;
        string originalText = string.Empty;
        string encryptedText = string.Empty;

        var sm4Methods = new SM4Methods(); // SM4 metodu

        if (actionType == "Encrypt" && !string.IsNullOrEmpty(inputTextEncrypt))
        {
            encryptedText = sm4Methods.SM4Encrypt(inputTextEncrypt, key); // Şifrələmə
            resultType = "Encryption Result";
            result = encryptedText;
            originalText = inputTextEncrypt;
        }
        else if (actionType == "Decrypt" && !string.IsNullOrEmpty(inputTextDecrypt))
        {
            result = sm4Methods.SM4Decrypt(inputTextDecrypt, key); // Deşifrələmə
            resultType = "Decryption Result";
            originalText = inputTextDecrypt;
            encryptedText = result;  // Deşifrələdikdən sonra şifrələnmiş mətn də göstərilir
        }

        // Nəticə və digər məlumatları ViewBag-də göndəririk
        ViewBag.Result = result;
        ViewBag.ResultType = resultType;
        ViewBag.OriginalText = originalText;
        ViewBag.EncryptedText = encryptedText;
        ViewBag.Key = key;

        return View();
    }


}

