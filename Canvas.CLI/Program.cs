using Canvas.CLI.Models;
using System;

namespace Canvas 
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Student> enrollments = new List<Student>();
            StudentMenu(enrollments);
        }

        static void StudentMenu(List<Student> enrollments)
        {
            while (true)
            {
                Console.WriteLine("C. Create a Student");
                Console.WriteLine("R. List Students");
                Console.WriteLine("U. Update a Student");
                Console.WriteLine("D. Delete a Student");
                Console.WriteLine("Q. Quit");

                var choice = Console.ReadLine() ?? string.Empty;

                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Create stuff
                    Console.WriteLine("Id: ");
                    var Id = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("Name: ");
                    var name = Console.ReadLine();

                    enrollments.Add(
                        new Student
                        {
                            Id = Id,
                            Name = name ?? "John/Jane Doe"
                        }
                    );

                }
                else if (choice.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Read stuff
                    enrollments.ForEach(Console.WriteLine);

                }
                else if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Update stuff
                    Console.WriteLine("Which student should be updated?");
                    enrollments.ForEach(Console.WriteLine);
                    var updateChoice = int.Parse(Console.ReadLine() ?? "0");

                    var studentToUpdate = enrollments.FirstOrDefault(s => s.Id == updateChoice);
                    if (studentToUpdate != null)
                    {
                        Console.WriteLine("What is the student's updated name?");
                        studentToUpdate.Name = Console.ReadLine() ?? "John/Jane Doe";
                    }
                }
                else if (choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Delete stuff
                    Console.WriteLine("Which student should be deleted?");
                    enrollments.ForEach(Console.WriteLine);
                    var deleteChoice = int.Parse(Console.ReadLine() ?? "0");

                    var studentToRemove = enrollments.FirstOrDefault(s => s.Id == deleteChoice);
                    if (studentToRemove != null)
                    {
                        enrollments.Remove(studentToRemove);
                    }
                }
                else if (choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry, that functionality isn't supported");
                }
            }
        }
    }
}