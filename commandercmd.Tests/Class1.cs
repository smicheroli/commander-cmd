using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace commandercmd.Tests
{
    namespace StringTester
    {
        [TestClass]
        public class setColorTests
        {
            [TestMethod]
            public void TestStringWithTwoLetters()
            {
                // Define the input string
                string input = "AB";

                // Check if the input string is 2 letters long
                Assert.AreEqual(2, input.Length, "The input string must be 2 letters long.");

                // Split the input string into two parts
                string firstPart = input.Substring(0, 1);
                string secondPart = input.Substring(1, 1);

                // Check if the first part is the first letter of the input string
                Assert.AreEqual("A", firstPart, "The first part must be the first letter of the input string.");

                // Check if the second part is the second letter of the input string
                Assert.AreEqual("B", secondPart, "The second part must be the second letter of the input string.");
            }
        }
    }
}
