using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TastManager.Models;
using Telerik.JustMock;

namespace TaskManager.Tests
{
    [TestClass]
    public class TestTaskManager
    {
        [TestMethod]
        public void TestTaskManager_WhenAddTask_ShouldCallLog()
        {
            // Agange
            var mockedLogger = new MockedLogger();
            var mockedIdProvider = new MockedIdProvider();

            

            var taskManager = new Tasker(mockedLogger, mockedIdProvider);

            var task = new Task("");

            // Act
            taskManager.Save(task);

            // Assert
            Assert.IsTrue(mockedLogger.IsLogCalled);
        }

        [TestMethod]
        public void TestTaskManager_WitMoq_WhenAllTasksCalled_ShouldCallLogTasksCount() //--> Nuget Moq and Justmock Packeges
        {
            ICollection<Task> tasks = new List<Task>()
            {
                new Task("nesto si"),
                new Task("i drugo")
            };


            // Agange
            var mockedLogger = new Mock<ILogger>();
            var mockedIdProvider = new Mock<IIdProvider>();
            var taskManager = new Tasker(mockedLogger.Object, mockedIdProvider.Object); //--> im Mock  => .Object

            taskManager.Tasks = tasks;

            mockedLogger.Setup(x => x.Log(It.IsAny<string>()));

            var task = new Task("");

            // Act
            taskManager.Save(task);

            // Assert
            mockedLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(taskManager.Tasks.Count));
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
            public int ID

            {
                get
                {
                    return 1;
                }
            }
        }
    }
}
