using System;
using System.Diagnostics;
using System.IO;
//Im gonna make it more responsive
namespace OpenSifteo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string project;                
                project = Console.ReadLine();
                string []final = project.Split(' ');
                if (final[0] == "make")//add try catch here
                {
                    build(final[1]);
                }
                else
                {
                    open(final[0]);
                }
            }
        }

        public static void open(string project)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = "CMD.exe";
            p1.StartInfo.RedirectStandardInput = true;
            p1.StartInfo.UseShellExecute = false;

            p1.Start();
            using (StreamWriter sw = p1.StandardInput)
            {
                sw.WriteLine("cd C:\\Users\\Cvmcosta\\Desktop\\Cvmfortress\\CP\\Laws\\sifteo\\sdk\\bin");
                sw.WriteLine(String.Format("siftulator C:\\Users\\Cvmcosta\\Desktop\\Cvmfortress\\CP\\Laws\\sifteo\\sdk\\examples\\{0}\\{0}.elf", project));
                sw.WriteLine("exit");
            }
            p1.Close();
        }
        public static void build(string project)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = "CMD.exe";
            p1.StartInfo.RedirectStandardInput = true;
            p1.StartInfo.UseShellExecute = false;

            p1.Start();
            using (StreamWriter sw = p1.StandardInput)
            {
                sw.WriteLine("rem SDK Setup Script for Windows");
                sw.WriteLine("set PATH=C:\\Users\\Cvmcosta\\Desktop\\Cvmfortress\\CP\\Laws\\sifteo\\sdk\\bin;%PATH%");
                sw.WriteLine(String.Format("cd C:\\Users\\Cvmcosta\\Desktop\\Cvmfortress\\CP\\Laws\\sifteo\\sdk\\examples\\{0}", project));
                sw.WriteLine("make");
                sw.WriteLine("exit");
            }
            p1.Close();
        }
    }
}
