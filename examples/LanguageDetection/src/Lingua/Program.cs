using System;

namespace Lingua
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "Hello, world!";

            var detector = new Detector();
            var languageCode = detector.DetectLanguage(input);

            Console.WriteLine(GetLanguage(languageCode));
        }

        static string GetLanguage(int languageCode) => languageCode switch
        {
            1 => "German",
            2 => "English",
            3 => "French",
            4 => "Italian",
            _ => "Unknown",
        };
    }
}
