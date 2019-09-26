using System;
using NUnit.Framework;

namespace _3Lab.Tests
{
    [TestFixture]
    public class CreateTriangleTests
    {
        [TestCase]
        public void NotNegativeInput()
        {
            Assert.IsTrue(!Triangle.CreateTriangle(-5, 10, 10), "Error in NotNegativeInput X");
            Assert.IsTrue(!Triangle.CreateTriangle(5, -10, 10), "Error in NotNegativeInput Y");
            Assert.IsTrue(!Triangle.CreateTriangle(5, 10, -10), "Error in NotNegativeInput Z");
        }
        [TestCase]
        public void NotLine()
        {
            Assert.IsTrue(!Triangle.CreateTriangle(5, 5, 10), "Error in NotLine 1");
            Assert.IsTrue(!Triangle.CreateTriangle(5, 10, 5), "Error in NotLine 2");
            Assert.IsTrue(!Triangle.CreateTriangle(10, 5, 5), "Error in NotLine 3");
        }
        [TestCase]
        public void CorrectEntries()
        {
            Assert.IsTrue(Triangle.CreateTriangle(5, 5, 5), "Error in CorrectEntries");
            Assert.IsTrue(Triangle.CreateTriangle(5, 6, 7), "Error in CorrectEntries");
            Assert.IsTrue(Triangle.CreateTriangle(5, 10, 10), "Error in CorrectEntries");
        }
        [TestCase]
        public void ZeroInput()
        {
            Assert.IsTrue(!Triangle.CreateTriangle(0, 5, 5), "Error in ZeroInput X");
            Assert.IsTrue(!Triangle.CreateTriangle(5, 0, 5), "Error in ZeroInput Y");
            Assert.IsTrue(!Triangle.CreateTriangle(5, 5, 0), "Error in ZeroInput Z");
        }
        [TestCase]
        public void AreEnoughLineLengths()
        {
            Assert.IsTrue(!Triangle.CreateTriangle(10, 1, 1), "Error in AreEnoughLineLengths 1");
            Assert.IsTrue(!Triangle.CreateTriangle(1, 10, 1), "Error in AreEnoughLineLengths 2");
            Assert.IsTrue(!Triangle.CreateTriangle(1, 1, 10), "Error in AreEnoughLineLengths 3");
        }
    }
}

namespace _3Lab
{
    public static class Triangle
    {
        public static bool CreateTriangle(double x, double y, double z)
        {
            if (((x + y) > z) && ((x + z) > y) && ((z + y) > x))
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
