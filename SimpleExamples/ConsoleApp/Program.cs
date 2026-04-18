using ConsoleApp.Entities;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var student = new Student("John", "Doe");
            Console.WriteLine($"Student ID: {student.Id}");
            Console.WriteLine($"Student Name: {student.FullName}");
        }
    }
}
