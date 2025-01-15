using System.IO;
using System.Numerics;
using System.Threading.Tasks;

namespace TakFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\programingLanguage\c#\TakFile\bin\Debug\net8.0\FirstFile.txt";

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to appliction: ");
                Console.WriteLine("1)Add task\n2)Display all tasks\n3)Check task\n4)Gaming\n0)Exit");
                Console.ForegroundColor = ConsoleColor.White;

                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        addRecord(path);
                        break;
                    case "2":
                        readRecord(path);
                        break;
                    case "3":
                        markTask(path);
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("==============");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
        private static void addRecord(string path)
        {
            int id = 1;

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields[0] == id.ToString())
                    {
                        id++;
                    }
                }
                reader.Close();
                Console.WriteLine();
            }

            StreamWriter streamWriter = new StreamWriter(path, true);
            try
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter task Title: ");
                string titleTask = Console.ReadLine();
                streamWriter.WriteLine(id.ToString() + "," + titleTask);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                streamWriter.Close();
                Console.WriteLine("=======================");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private static void readRecord(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(streamReader.ReadToEnd());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                streamReader.Close();
                Console.WriteLine("=======================");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private static void markTask(string path)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter id for task: ");

            int id = int.Parse(Console.ReadLine());
            id--;

            string newValue = "completed";

            string[] lines = File.ReadAllLines(path);

            lines[id] += $"->({newValue})";

            File.WriteAllLines(path, lines);
            Console.WriteLine("=======================");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
