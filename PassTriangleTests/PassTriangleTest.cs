using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PassTriangleTests
{
    [TestClass]
    public class PassTriangleTest
    {
        List<List<int>> testTriangle = new List<List<int>>() { new List<int>() { 5 }, new List<int>() { 9, 6 }, new List<int>() { 4, 6, 8 }, new List<int>() { 0, 7, 1, 5 } };

        [TestMethod]
        public void TestLoadTriangle()
        {
            var rawLines = new List<string>() {"5", "9 6", "4 6 8", "0 7 1 5"};
            
            var triangle = Program.LoadTriangle(rawLines);

            for (int i = 0; i < triangle.Count; i++)
            {
                CollectionAssert.AreEqual(testTriangle[i], triangle[i], i + " element not equal");    
            }
            
        }

        [TestMethod]
        public void TestWalkTriangle()
        {
            var actual = Program.WalkTriangle(testTriangle);
            var expected = 27;
            Assert.AreEqual(expected, actual);
        }
    }
}
