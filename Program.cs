using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace cheatkiller
{
    class Program
    {
        static void Main(string[] args)
        {
            string startText = File.ReadAllText("ck.txt");
            Console.WriteLine(startText);
        
            Console.Write("Process Name: ");
            string processName = Console.ReadLine();
            Console.WriteLine("-----------------------------------------------------------------------------");

            
            Process proc = Process.GetProcessesByName(processName)[0];
            
            string[] startModules = new string[proc.Modules.Count+1];

            for(int i = 0; i < proc.Modules.Count; i++){
                startModules[i] = proc.Modules[i].ToString();
            }
            for(int i = 0; i <= proc.Modules.Count; i++)
                Console.WriteLine(startModules[i]);
            for(;;){
                Process proc2 = Process.GetProcessesByName(processName)[0];
                Thread.Sleep(5000);
                string[] secondModules = new string[proc2.Modules.Count+1];
                for(int i = 0; i < proc2.Modules.Count; i++){
                    secondModules[i] = proc2.Modules[i].ToString();
                }
                for(int i = 0; i <= proc2.Modules.Count; i++)
                    Console.WriteLine(secondModules[i]);


                if(startModules.Length == secondModules.Length){
                    Console.WriteLine("Первая Проверка пройдена!\n");
                }
                else{
                    Console.WriteLine("Первая проверка не пройдена!");
                    proc.Kill();
                    return;
                }

                for(int i = 0; i < startModules.Length; i++){
                    if(startModules[i] != secondModules[i]){
                        Console.WriteLine("Вторая проверка не пройдена!\n");
                        proc.Kill();
                        Environment.Exit(0);
                    }
                }

                Console.WriteLine("Вторая проверка пройдена!\n");
                
            }
        }
    }
}
