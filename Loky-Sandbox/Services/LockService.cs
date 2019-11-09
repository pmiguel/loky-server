namespace LokySandbox.Services
{
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    public class LockService
    {
        [DllImport("user32")]
        private static extern void LockWorkStation();
        
        public static async Task Lock(int delayMs = 0)
        {
            await Task.Delay(delayMs);
            LockWorkStation();
        }
    }
}