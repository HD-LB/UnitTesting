using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskManager.Models;
using TaskManager.Models.Contracts;

namespace TaskManager.Tests
{
    [TestClass]
    public class TestTaskManager
    {
        [TestMethod]
        public void TestTaskManager_WithMoq_WhenAddTask_ShouldCallLog()
        {
            // Arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedIdProvider = new Mock<IIdProvider>();

            var taskManager = new Tasker(mockedLogger.Object, mockedIdProvider.Object);

            mockedLogger.Setup(x => x.Log(It.IsAny<string>()));

            var task = new Task("");

            // Act 
            taskManager.Save(task);

            // Assert
            mockedLogger.Verify();
        }

        [TestMethod]
        public void TestTaskManager_WithMoq_WhenAllTasksCalled_ShouldCallLogTasksCount()
        {
            ICollection<Task> tasks = new List<Task>()
            {
                new Task("something"),
                new Task("else")
            };

            // Arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedIdProvider = new Mock<IIdProvider>();

            var taskManager = new Tasker(mockedLogger.Object, mockedIdProvider.Object);
            taskManager.Tasks = tasks;

            //mockedLogger.Setup(x => x.Log(It.IsAny<string>()));
                       

            // Act 
            taskManager.AllTasks();

            // Assert
            mockedLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(taskManager.Tasks.Count));
           
        }

        [TestMethod]
        public void TestTaskManager_WitMoq_WhenNullAdded_ShouldThrowArgNullException()
        {
            // Arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedIdProvider = new Mock<IIdProvider>();

            var taskManager = new Tasker(mockedLogger.Object, mockedIdProvider.Object);

            mockedLogger.Setup(x => x.Log(It.IsAny<string>())).Throws<ArgumentNullException>();

            var task = new Task("");

            // Act 
            taskManager.Save(task);

            // Assert
            mockedLogger.Verify();
        }

        [TestMethod]
        public void TestTaskManager_WitMoq_WhenSaved_ShouldCallIdProvider()
        {
            // Arrange
            var mockedLogger = new Mock<ILogger>();
            var mockedIdProvider = new Mock<IIdProvider>();

            var taskManager = new Tasker(mockedLogger.Object, mockedIdProvider.Object);

            mockedIdProvider.Setup(x => x.Id).Returns(1);

            var task = new Task("");

            // Act 
            taskManager.Save(task);

            // Assert
            mockedIdProvider.Verify();
        }

        public class MockedLogger : ILogger
        {
            public bool IsLogCalled;
            public void Log(string msg)
            {
                this.IsLogCalled = true;
            }
        }

        public class MockedIdProvider : IIdProvider
        {
            public int Id
            {
                get
                {
                    return 1;
                }
            }
        }
    }
}
