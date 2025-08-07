using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Poll_Voting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] validCandidates = { "Alice", "Bob", "Charlie" };
            string[] votes = new string[10];

            Console.WriteLine("Voting System");
            Console.WriteLine($"Candidates: {string.Join(", ", validCandidates)}\n");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Enter vote {i + 1} (Alice/Bob/Charlie): ");
                string input = Console.ReadLine()?.Trim();

                while (!validCandidates.Any(c =>
                       string.Equals(c, input, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Invalid candidate. Please try again.");
                    Console.Write($"Enter vote {i + 1} (Alice/Bob/Charlie): ");
                    input = Console.ReadLine()?.Trim();
                }

                votes[i] = input;
            }
            int aliceCount = votes.Count(v =>
                       string.Equals(v, "Alice", StringComparison.OrdinalIgnoreCase));
            int bobCount = votes.Count(v =>
                         string.Equals(v, "Bob", StringComparison.OrdinalIgnoreCase));
            int charlieCount = votes.Count(v =>
                             string.Equals(v, "Charlie", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("\nVote Count:");
            Console.WriteLine($"Alice: {aliceCount} votes");
            Console.WriteLine($"Bob: {bobCount} votes");
            Console.WriteLine($"Charlie: {charlieCount} votes");

            string winner = "No winner";
            int maxVotes = Math.Max(aliceCount, Math.Max(bobCount, charlieCount));

            if (maxVotes > 0)
            {
                if (aliceCount == maxVotes && aliceCount != bobCount && aliceCount != charlieCount)
                    winner = "Alice";
                else if (bobCount == maxVotes && bobCount != charlieCount)
                    winner = "Bob";
                else if (charlieCount == maxVotes)
                    winner = "Charlie";
                else
                    winner = "Tie between " +
                            string.Join(" and ",
                                new[] {
                                (aliceCount == maxVotes ? "Alice" : null),
                                (bobCount == maxVotes ? "Bob" : null),
                                (charlieCount == maxVotes ? "Charlie" : null)
                                }
                                .Where(x => x != null));
            }
            Console.WriteLine($"\nWinner: {winner}");
        }
    }
}
