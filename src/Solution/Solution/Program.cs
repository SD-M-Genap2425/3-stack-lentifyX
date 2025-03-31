using Solution.BracketValidation;
using Solution.BrowserHistory;
using Solution.Palindrome;

namespace Solution;

internal class Program
{
    static void Main(string[] args)
    {
        // Browser history
        var browser = new Solution.BrowserHistory.HistoryManager();
        browser.KunjungiHalaman("google.com");
        browser.KunjungiHalaman("example.com");
        browser.KunjungiHalaman("stackoverflow.com");
        Console.WriteLine($"Halaman saat ini: {browser.LihatHalamanSaatIni()}");
        browser.Kembali();
        Console.WriteLine($"Halaman saat ini setelah kembali: {browser.LihatHalamanSaatIni()}");

        // Bracket validator
        string ekspresiValid = "[{}](){}";
        string ekspresiInvalid = "(]";

        var BracketValidator = new Solution.BracketValidation.BracketValidator();
        Console.WriteLine($"Ekspresi '{ekspresiValid}' valid? {BracketValidator.ValidasiEkspresi(ekspresiValid)}");
        Console.WriteLine($"Ekspresi '{ekspresiInvalid}' valid? {BracketValidator.ValidasiEkspresi(ekspresiInvalid)}");

        //Palindrome Checker
        string palindrom = "Kasur ini rusak";
        string bukanPalindrom = "Hello World";
        Console.WriteLine($"'{palindrom}' adalah palindrom? {Solution.Palindrome.PalindromeChecker.CekPalindrom(palindrom)}");
        Console.WriteLine($"'{bukanPalindrom}' adalah palindrom? {Solution.Palindrome.PalindromeChecker.CekPalindrom(bukanPalindrom)}");


    }
}
