using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class EmailEntry
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
    }

    public static class _182_DuplicateEmails
    {
        public static void Run()
        {
            var people = new List<EmailEntry>
            {
                new EmailEntry { Id = 1, Email = "a@b.com" },
                new EmailEntry { Id = 2, Email = "c@d.com" },
                new EmailEntry { Id = 3, Email = "a@b.com" }
            };

            var duplicateEmails = people
                .GroupBy(p => p.Email)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            Console.WriteLine("Duplicate Emails:");
            foreach (var email in duplicateEmails)
                Console.WriteLine(email);
        }
    } 
}
