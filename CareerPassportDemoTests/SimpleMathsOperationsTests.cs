using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CareerPassportDemoTests
{
    [TestClass()]
    public class SimpleMathsOperationsTests
    {
        private readonly SimpleMathsOperations _simpleMathsOperations;

        public SimpleMathsOperationsTests()
        {
            _simpleMathsOperations = new ();
        }

        [TestMethod()]
        public void AddNumbersTest()
        { 
            //Act
            var result = _simpleMathsOperations.AddNumbers(8.7, 5.4);

            //Assert
            Assert.AreEqual(14.1, result);
        }

        [TestMethod()]
        public void SubtractNumbersTest()
        {
            //Act
            var result = _simpleMathsOperations.SubtractNumbers(8.7, 5.4);

            //Assert
            Assert.AreEqual(3.3, Math.Round(result, 2));
        }

        [TestMethod()]
        public void MultiplyNumbersTest()
        {
            //Act
            var result = _simpleMathsOperations.MultiplyNumbers(5.5, 3);

            //Assert
            Assert.AreEqual(16.5, result);
        }

        [TestMethod()]
        public void DivideNumbersTest()
        {
            //Act
            var result = _simpleMathsOperations.DivideNumbers(8.7, 5.8);

            //Assert
            Assert.AreEqual(1.5, result);
        }

        [TestMethod()]
        public void SquareNumberTest()
        {
            //Act
            var result = _simpleMathsOperations.SquareNumber(4.5);

            //Assert
            Assert.AreEqual(20.25, result);
        }
    }
}