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

            Console.WriteLine(Detector.GetLanguage(languageCode));
        }
    }
}
