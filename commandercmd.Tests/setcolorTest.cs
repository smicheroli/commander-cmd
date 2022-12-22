using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplicationTests
{
    [TestClass]
    public class setcolorTest
    {
        [TestMethod]
        public void TestValidForegroundColor()
        {
            // Arrange
            ConsoleColor expectedColor = ConsoleColor.DarkGreen;
            string setcolor = "GRUEN";
            colorCommand command = new colorCommand("color", setcolor);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(expectedColor, Console.ForegroundColor);
        }

        [TestMethod]
        public void TestValidBackgroundColor()
        {
            // Arrange
            ConsoleColor expectedColor = ConsoleColor.DarkRed;
            string setcolor = "WEISS ROT";
            colorCommand command = new colorCommand("color", setcolor);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(expectedColor, Console.BackgroundColor);
        }

        [TestMethod]
        public void TestInvalidColor()
        {
            // Arrange
            string setcolor = "INVALID_COLOR";
            colorCommand command = new colorCommand("color", setcolor);
            Console.SetOut(new StringWriter());

            // Act
            command.Execute();
            string output = Console.Out.ToString();

            // Assert
            Assert.IsTrue(output.Contains("Invalid color"));
        }
    }
}