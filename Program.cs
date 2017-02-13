using System;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        static FileLogWriter Logger;
        public static void Main(string[] args)
        {
            Logger = new FileLogWriter("debug.txt");
            Log("Application started");
            Log("Application running");
            Console.WriteLine("Hello World!");
            Log("Application exited");
            Console.Read();
        }

        static void Log(string content)
        {
            Task.Run(() => Logger.Write(content));
        }
    }
}
