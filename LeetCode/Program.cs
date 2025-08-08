using System;
using LeetCode.Problems;

namespace LeetCodeSeries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== LeetCode Series ===");
            Console.WriteLine("Select a problem to run:");
            Console.WriteLine("182. Duplicate Emails");
            Console.WriteLine("1719. Number of Ways to Reconstruct a Tree");
            Console.WriteLine("0. Exit");

            Console.Write("\nChoice: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine(); // spacing

            switch (choice)
            {
                case "182":
                    _182_DuplicateEmails.Run();
                    break;
                case "1719":
                    new _1719_NumberOfWaysToReconstructATree().Run();
                    break;
                case "0":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
