using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCalculator;
using System.Text;
using System.Collections.Generic;

namespace CalculatorTest
{
    [TestClass]
    public class CalculatorTests
    {
        [TestInitialize]
        public void TestInit() 
        {

         }
        [TestMethod]
        public void Add()
        {
            Calculator calculator = new Calculator(-100,100);
            int result = calculator.Add(2, 2);
            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void AddWithDifferentArguments()
        {
            Calculator calculator = new Calculator(-100,100);
            int result = calculator.Add(2, 5);
            Assert.AreEqual(7, result);
        }
        [TestMethod]
        public void Substract()
        {
            Calculator calculator = new Calculator(-100,100);
            int result = calculator.Substract(5, 3);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void SubstractReturningNegative()
        {
            Calculator calculator = new Calculator(-100,100);
            int result = calculator.Substract(3, 5);
            Assert.AreEqual(-2, result);
        }
        [TestMethod]
        public void SubstractSettingLimitValues()
        {
            Calculator calculator = new Calculator(-100, 100);
            try
            {
                int result = calculator.Substract(10, 150);
                Assert.Fail("Exception is not being thrown when " + "exceeding lower limit");
            }
            catch (OverflowException)
            {
                
                // Ok, the SUT works as expected
            }
        }
        [TestMethod]
        public void AddExcedingUpperLimi()
        {
            Calculator calculator = new Calculator(-100, 100);
            try
            {
                int result = calculator.Add(10, 150);
                Assert.Fail("This should fail: we’re exceding upper limit");
            }
            catch (OverflowException)
            {

                // Ok, the SUT works as expected
            }
        }
        [TestMethod]
        public void ArgumentsExceedLimits()
        {
            Calculator calculator = new Calculator(-100, 100);
            try
            {
                calculator.ValidateArgs(calculator.UpperLimit + 1, calculator.LowerLimit - 1);
                Assert.Fail("This should fail: arguments exceed limits");
            }
            catch (OverflowException)
            {

                // Ok, the SUT works as expected
            }
        }
        [TestMethod]
        public void ArgumentsExceedLimitsInverse()
        {
            Calculator calculator = new Calculator(-100, 100);
            try
            {
                calculator.ValidateArgs(calculator.LowerLimit - 1, calculator.UpperLimit + 1);
                Assert.Fail("This should fail: arguments exceed limits");
            }
            catch (OverflowException)
            {

                // Ok, the SUT works as expected
            }
        }
        [TestMethod]
        public void ArgumentsExceedLimitsOnSubstract()
        {
            Calculator calculator = new Calculator(-100, 100);
            try
            {
                calculator.Substract(calculator.UpperLimit + 1, calculator.LowerLimit - 1);
                Assert.Fail("This should fail: arguments exceed limits");
            }
            catch (OverflowException)
            {

                // Ok, the SUT works as expected
            }
        }

        [TestMethod]
        public void SetAndGetUpperLimit()
        {
            Calculator calculator = new Calculator(-100, 100);
            Assert.AreEqual(100, calculator.UpperLimit);
            Assert.AreEqual(-100, calculator.LowerLimit);
        }

    }
}
