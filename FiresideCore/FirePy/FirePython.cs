using System.Diagnostics;
using System.IO;

namespace FiresideCore.FirePy
{
    public class FirePython
    {
        /// <summary>
        /// Path to the python.exe
        /// </summary>
        public static string PyPath;
        
        public static string RunCommand(string cmd, string args)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = PyPath,
                Arguments = $"{cmd} {args}",
                UseShellExecute = false,
                RedirectStandardOutput = true
            };
            using (var process = new Process())
            {
                using (var reader = process.StandardOutput)
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}