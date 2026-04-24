using ConsoleApp.Entities;

namespace ConsoleApp.UnitTest
{
    //create unit test for Student class using xUnit
    public class StudentTests
    {
        [Fact]
        public void Student_Should_Have_FirstName_And_LastName()
        {
            // Arrange
            var student = new Student("John", "Doe");
            // Act
            var firstName = student.FirstName;
            var lastName = student.LastName;
            // Assert
            Assert.Equal("John", firstName);
            Assert.Equal("Doe", lastName);
        }
        [Fact]
        public void Student_Should_Have_Valid_Id()
        {
            // Arrange
            var student = new Student("John", "Doe");
            // Act
            var id = student.Id;
            // Assert
            Assert.NotEqual(Guid.Empty, id);
        }
        [Fact]
        public void Student_Should_Return_FullName()
        {
            // Arrange
            var student = new Student("John", "Doe");
            // Act
            var fullName = student.FullName;
            // Assert
            Assert.Equal("John Doe", fullName);
        }
    }

}
