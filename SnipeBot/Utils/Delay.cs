using System.Threading.Tasks;

namespace SnipeBot.Utils
{
    public static class T
    {
        public static async Task Delay(int delay)
        {
            await Task.Delay(delay);
        }
    }
}
