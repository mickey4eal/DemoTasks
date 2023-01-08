using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CareerPassportDemoTests
{
    [TestClass()]
    public class AccumulateTests
    {
        //To Do: c# how to unit test a static class
        //https://www.infoworld.com/article/3571962/how-to-unit-test-static-methods-in-csharp.html#:~:text=How%20to%20unit%20test%20static%20methods%20in%20C%23,create%20a%20unit%20test%20method%20in%20C%23%20
        [TestMethod()]
        public static void AccumulateOperationsTest()
        {
            //Arrange and Act
            var result = Accumulate.AccumulateOperations(new int[] { 1, 2, 3, 4, 5 }, x => x * x);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            Assert.IsTrue(result.Any(x => x.Equals(1)));
            Assert.IsTrue(result.Any(x => x.Equals(4)));
            Assert.IsTrue(result.Any(x => x.Equals(9)));
            Assert.IsTrue(result.Any(x => x.Equals(16)));
            Assert.IsTrue(result.Any(x => x.Equals(25)));
        }
    }
}