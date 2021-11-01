using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utilities.Tests
{

    [TestClass] //Add Reference --> Assebly --> Microsoft.VisualStudio.TestTools.UnitTesting.Framework
    public class TestUtils
    {
        //[TestMethod]
        //public void MathUtils_SumTwoNumbers_SchouldSumRight()
        //{
        //    var utils = new MathUtils();
        //    int a = 0;
        //    int b = 5;

        //    var result = utils.Sum(a, b);

        //    Assert.AreEqual(5, result);

        //}

        //Field
        private TestContext context;

        //Propartie
        public TestContext Context
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
            }
        }

        //Add Reference --> Projects --> Utilities

        [DeploymentItem(".\\Data.xml"), TestMethod] //make a xml-File --> Add --> new Project --> XML File
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", ".\\Data.xml", "Row", DataAccessMethod.Sequential)]
        public void MathUnil_SumTwoNumbers_ShouldSumRight()
        {
            //Arange
            var utils = new MathUtils();
            int a = int.Parse((string)Context.DataRow["A"]);
            int b = int.Parse((string)Context.DataRow["B"]);
            int res = int.Parse((string)Context.DataRow["Expected"]);

            var result = utils.Sum(a, b);

            //Act
            Assert.AreEqual(res, result); //expected Answer is a + b and is compared to the result
            
        }
    }
}
