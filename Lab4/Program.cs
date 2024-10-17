using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentCollection studentCollection = new StudentCollection();
            try
            {
                studentCollection.AddStudent(new Student("Ivanenko", "Group A", "Paid", 99));
                studentCollection.AddStudent(new Student("Petrenko", "GroupB", "Free", 95));
                studentCollection.AddStudent(new Student("Timchenko", "Group A", "Paid", 97));
                studentCollection.AddStudent(new Student("Kovalenko", "Group C", "Paid", 100));

                Console.WriteLine("List of students:");
                studentCollection.DisplayStudents();

                studentCollection.SortStudentsByAverageScore();
                Console.WriteLine("\nList of students after softing by average score:");
                studentCollection.DisplayStudents();

                studentCollection.FilterStudentsByGroup("Group B");
                Console.WriteLine("\nList of students after filtering by group:");
                studentCollection.DisplayStudents();

                string filePath = "students.txt";
                studentCollection.SaveToFile(filePath);
                Console.WriteLine($"\nList of students saved into file: {filePath}");

                StudentCollection loadedCollection = new StudentCollection();
                loadedCollection.LoadFromFile(filePath);
                Console.WriteLine("\nLoaded list of students from file:");
                loadedCollection.DisplayStudents();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
