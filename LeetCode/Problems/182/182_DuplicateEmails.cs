using System;
using System.Collections.Generic; 
using System.Linq;

namespace LeetCode.Problems._182
{
    public class emailList
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }

    static void Run()
        {
            // Example input data (same as LeetCode #182 example)
            List<emailList> people = new List<emailList>
        {
            new emailList { Id = 1, Email = "a@b.com" },
            new emailList { Id = 2, Email = "c@d.com" },
            new emailList { Id = 3, Email = "a@b.com" }
        };

            // LINQ query to find duplicates
            var duplicateEmails = people
                .GroupBy(p => p.Email)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            // Output results
            Console.WriteLine("Duplicate Emails:");
            foreach (var email in duplicateEmails)
            {
                Console.WriteLine(email);
            }
        }
    } 
}
