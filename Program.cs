using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARRAY_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int studentCount = 5;
            const int subjectCount = 3;

            string[] studentNames = new string[studentCount];
            int[,] grades = new int[studentCount, subjectCount];
            int[] totals = new int[studentCount];

            Console.WriteLine("Enter grades for 5 students");

            for (int i = 0; i < studentCount; i++)
            {
                Console.Write($"\nStudent {i + 1} name: ");
                studentNames[i] = Console.ReadLine();

                for (int j = 0; j < subjectCount; j++)
                {
                    while (true)
                    {
                        Console.Write($"Subject {j + 1} grade (0-100): ");
                        if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 0 && grade <= 100)
                        {
                            grades[i, j] = grade;
                            totals[i] += grade;
                            break;
                        }
                        Console.WriteLine("Invalid input. Grade must be 0-100.");
                    }
                }
            }

            var students = Enumerable.Range(0, studentCount)
                .Select(i => new
                {
                    Index = i,
                    Name = studentNames[i],
                    Total = totals[i],
                    Average = (double)totals[i] / subjectCount
                })
                .OrderByDescending(s => s.Total)
                .ToList();

            Console.WriteLine("\nRanking Results");
            Console.WriteLine("Rank\tName\t\tTotal\tAverage");
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < students.Count; i++)
            {
                var student = students[i];
                Console.WriteLine($"{i + 1}\t{student.Name}\t\t{student.Total}\t{student.Average:F1}");
            }

            var topStudent = students.First();
            Console.WriteLine($"\nTop Student: {topStudent.Name} with {topStudent.Total} points!");
        }
    }
}
