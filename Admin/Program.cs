using System;
using System.Diagnostics;
using System.Text;
/// <summary>
/// Brychan Dempsey 2020.
/// </summary>
namespace Admin
{
    /// <summary>
    /// Launches an administrator powershell when called (admin). Blocked from execution in System32; create a new folder and add it to the path.
    /// Can be called in the same form as sudo in Debian & Ubuntu. (e.g. admin ping 1.1.1.1)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string argString = "";
            // Converting args to base64 ensures correct handling of the command, regardless of escaped characters etc.
            if (args.Length > 0)
            {
                argString = "-noExit -encodedCommand ";
                string conversion = "";
                foreach (string arg in args)
                {
                    conversion += arg + " ";
                }
                argString += Convert.ToBase64String(Encoding.Unicode.GetBytes(conversion));
            }
            Process newWindow = new Process();
            newWindow.StartInfo.FileName = "powershell";
            newWindow.StartInfo.Verb = "runas";
            newWindow.StartInfo.Arguments = argString.Trim();
            newWindow.StartInfo.UseShellExecute = true;
            newWindow.Start();
        }
    }
}
