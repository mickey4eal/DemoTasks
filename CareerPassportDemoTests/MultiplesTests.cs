namespace CareerPassportDemoTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class MultiplesTests
    {
        private readonly Multiples _multiples;

        public MultiplesTests()
        {
            _multiples = new();
        }

        [TestMethod()]
        public void SumOfMultiplesWithOneFactor()
        {
            //Act
            var result = _multiples.SumOfMultiples(4, 50);

            //Assert
            Assert.AreEqual(312, result);
        }

        [TestMethod()]
        public void SumOfMultiplesWithTwoFactors()
        {
            //Act
            var result = _multiples.SumOfMultiples(new int[] { 4, 7 }, 50);

            //Assert
            Assert.AreEqual(480, result);
        }
    }
}