using UnknownScheduler.Core;
using UnknownScheduler.Solutions.Example;

namespace UnknownScheduler
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            IServiceRunner serviceRunner = new ServiceRunner();
            serviceRunner.Run();
        }
    }
}