using System;
using System.Diagnostics;
using System.IO;
using System.Threading;



namespace sifteoOpenner
{
    class Program
    {
        public static string url = Properties.Settings.Default.Url;

        static void Main(string[] args)
        {

            if (Properties.Settings.Default.IsFirstTime)
            {
                Properties.Settings.Default.IsFirstTime = !Properties.Settings.Default.IsFirstTime;
                Console.WriteLine("Insira o endereço da pasta projetos: ");
                Properties.Settings.Default.Url = Console.ReadLine();
                url = Properties.Settings.Default.Url;
                Properties.Settings.Default.Save();
            }
            else
            {
                Console.WriteLine("Deseja mudar o endereço de projetos? s/n :");
                string bol = Console.ReadLine();
                if (bol == "s" || bol == "S")
                {
                    Console.WriteLine("\nInsira o novo endereço da pasta projetos: ");
                    Properties.Settings.Default.Url = Console.ReadLine();
                    url = Properties.Settings.Default.Url;
                    Properties.Settings.Default.Save();
                }

            }
            Console.WriteLine("Se for apenas abrir, insira o nome do projeto. Se for conmpilar insira a palavra 'make' antes do nome do projeto que deseja compilar >>");
            Console.Write("\n--------------------------------\nInsira seu comando:\n>>");
            while (true)
            {
                string project;
                project = Console.ReadLine();
                Console.WriteLine("\n---------------------------------------");
                string[] final = project.Split(' ');
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
                else if (final[0] == "dir")
                {
                    srch();
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
                Thread.Sleep(800);
                Console.Write("\n-------------------------------\nInsira seu comando:\n>>");
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
                sw.WriteLine(String.Format("set SDK_DIR={0}", url));
                sw.WriteLine(String.Format("set PATH={0}\\bin;%PATH%", url));
                sw.WriteLine(String.Format("cd {0}\\projects\\{1}", url, project));
                sw.WriteLine("make");
                sw.WriteLine("exit");
                Thread.Sleep(2000);
                Console.Write("\n-------------------------------\nInsira seu comando:\n>>");
            }
            p1.Close();
        }
        public static void srch()
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = "CMD.exe";
            p1.StartInfo.RedirectStandardInput = true;
            p1.StartInfo.UseShellExecute = false;

            p1.Start();
            using (StreamWriter sw = p1.StandardInput)
            {
                sw.WriteLine(String.Format("cd {0}\\projects", url));
                sw.WriteLine("dir");

                Thread.Sleep(800);
                Console.Write("\n-------------------------------\nInsira seu comando:\n>>");
            }
            p1.Close();
        }

    }
}
