using System;
using NUnit.Framework;

namespace Lab3.Tests
{
    [TestFixture]
    public class CreateTriangleTests
    {
        [TestCase(-5, 10, 10)]
        [TestCase(5, -10, 10)]
        [TestCase(5, 10, -10)]
        public void NotNegativeInput(int x, int y, int z)
        {
            Assert.IsFalse(Triangle.IsTriangle(x, y, z), "Error in NotNegativeInput");
        }
        [TestCase(5, 5, 10)]
        [TestCase(5, 10, 5)]
        [TestCase(10, 5, 5)]
        public void NotLine(int x, int y, int z)
        {
            Assert.IsFalse(Triangle.IsTriangle(x, y, z), "Error in NotLine 1");
        }
        [TestCase(5, 5, 5)]
        [TestCase(5, 6, 7)]
        [TestCase(5, 10, 10)]
        public void CorrectEntries(int x, int y, int z)
        {
            Assert.IsTrue(Triangle.IsTriangle(x, y, z), "Error in CorrectEntries");
        }
        [TestCase(0, 5, 5)]
        [TestCase(5, 0, 5)]
        [TestCase(5, 5, 0)]
        public void ZeroInput(int x, int y, int z)
        {
            Assert.IsFalse(Triangle.IsTriangle(x, y, z), "Error in ZeroInput X");
        }
        [TestCase(10, 1, 1)]
        [TestCase(1, 10, 1)]
        [TestCase(1, 1, 10)]
        public void AreEnoughLineLengths(int x, int y, int z)
        {
            Assert.IsFalse(Triangle.IsTriangle(x, y, z), "Error in AreEnoughLineLengths 1");
        }
    }
}

namespace Lab3
{
    public static class Triangle
    {
        public static bool IsTriangle(double x, double y, double z)
        {
            return ((x + y) > z) && ((x + z) > y) && ((z + y) > x);
        }
    }
}