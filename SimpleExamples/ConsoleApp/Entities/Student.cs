using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Entities
{
    public class Student
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FirstName { get;  private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";

        private Student() { }
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
