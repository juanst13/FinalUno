using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace FinalUno.Skia.Tizen
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new FinalUno.App(), args);
            host.Run();
        }
    }
}
