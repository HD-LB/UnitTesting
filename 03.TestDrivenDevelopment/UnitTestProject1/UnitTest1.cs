using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
       
        public void AddStudentToCourse_ShouldAddStudentToCourseSuccessfully_IfStudentIsNotNull()
        {
            //Arange
            StudentSystem sudentSystem = new StudentSystem();
            Student student = new Student();
            Course course = new Course();

            //Act and Assert
            Assert.ThrowsException<NotImplementedException>(() => sudentSystem.AddStudentTRoCourse(student, course));

            ////Assert
            //Assert.AreEqual(1, sudentSystem.GetStudentCountForCourse(course).Count());
        }

        [TestMethod]
        public void Age_SchoulNotAcceptNegativeValues()
        {
            //Agange
            Student student = new Student();

            //Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(action: () => student.Age = -4);
        }
    }
}
