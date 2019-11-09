namespace LokySandbox
{
    using System;
    using System.Threading.Tasks;
    using Figgle;
    using LokySandbox.Services;
    
    class Program
    {
        public const string TITLE = "Loky Sandbox";
        public const string VERSION = "0.1";

        static async Task Main(string[] args)
        {
            Console.WriteLine(FiggleFonts.Bolger.Render(TITLE));
            Console.WriteLine($"\tv{VERSION}");
            Console.ReadKey();
            
            Console.WriteLine("Locking in 3 seconds...");

            await LockService.Lock();
            
            Console.WriteLine("Workstation locked.");
        }
    }
}