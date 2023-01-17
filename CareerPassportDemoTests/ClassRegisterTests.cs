namespace CareerPassportDemoTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class ClassRegisterTests
    {
        private ClassRegister? _classRegister;

        [TestMethod()]
        public void AddStudentTest()
        {
            //Arrange
            _classRegister = new();

            //Act
            _classRegister.AddStudent("Student A");
            var result = _classRegister.GetStudents();

            //Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Student A", result.First());
        }

        [TestMethod()]
        public void AddStudentsTest()
        {
            //Arrange
            _classRegister = new();

            //Act
            _classRegister.AddStudents(new string[] { "Student A", "Student B", "Student C" });
            var result = _classRegister.GetStudents();

            //Assert
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Student C", result.Last());
        }
    }
}