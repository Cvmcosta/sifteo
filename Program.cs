using System;
using System.Diagnostics;
using System.IO;
//Im gonna make it more responsive
namespace OpenSifteo
{
    class Program
    {
        public static string url = "C:\\Users\\Cvmcosta\\Desktop\\Cvmfortress\\CP\\Laws\\sifteo\\sdk";

        static void Main(string[] args)
        {
            while (true)
            {
                string project;                
                project = Console.ReadLine();
                string []final = project.Split(' ');
                if (final[0] == "make")//add try catch here
                {
                    try
                    {
                        build(final[1]);
                    }
                    catch
                    {
                        open(final[0]);
                    }
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
                sw.WriteLine(String.Format("cd {0}\\bin", url));
                sw.WriteLine(String.Format("siftulator {0}\\projects\\{1}\\{1}.elf", url, project));
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
                sw.WriteLine(String.Format("set PATH={0}\\bin;%PATH%", url));
                sw.WriteLine(String.Format("cd {0}\\examples\\{1}", url, project));
                sw.WriteLine("make");
                sw.WriteLine("exit");
            }
            p1.Close();
        }
    }
}
