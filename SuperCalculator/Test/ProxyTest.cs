using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperCalculator;
using System.Text;
using System.Collections.Generic;

namespace CalculatorTest
{

    [TestClass]
    public class ProxyTest
    {
        private Calculator _calculator;
        private CalcProxy _calcProxy;

        [TestMethod]
        public void Add()
        {
            _calculator = new Calculator();
            _calcProxy = new CalcProxy(new Validator(-10, 10), _calculator);
            int result = _calcProxy.BinaryOperation(_calculator.Add, 5, 2);

            Assert.AreEqual(7, result);
        }
        [TestMethod]
        public void Substract()
        {
            _calculator = new Calculator();
            _calcProxy = new CalcProxy(new Validator(-10, 10), _calculator);
            int result = _calcProxy.BinaryOperation(_calculator.Substract, 5, 3);

            Assert.AreEqual(2, result);
        }
	    
        [TestMethod]
	    public void AddWithDifferentArguments()
	    {
            _calculator = new Calculator();
            _calcProxy = new CalcProxy(new Validator(-10, 10), _calculator); 
            int result = _calcProxy.BinaryOperation(_calculator.Add, 2, 5);
		    Assert.AreEqual(7, result);
	    }

	    [TestMethod]
	    public void SubstractReturningNegative()
	    {
            _calculator = new Calculator();
            _calcProxy = new CalcProxy(new Validator(-10, 10), _calculator); 
            int result = _calcProxy.BinaryOperation(_calculator.Substract, 3, 5);
		    Assert.AreEqual(-2, result);
	    }
        [TestMethod]
        public void ArgumentsExceedLimits()
        {
            _calculator = new Calculator();
            CalcProxy calcProxyWithLimits = new CalcProxy(new Validator(-10, 10), _calculator);
            try
            {
                calcProxyWithLimits.BinaryOperation(_calculator.Add, 30, 50);
                Assert.Fail("This should fail as arguments exceed both limits");
            }
            catch (OverflowException)
            {

                // Ok, this works
            }
        }
        [TestMethod]
        public void ArgumentsExceedLimitsInverse()
        {
            _calculator = new Calculator();
            CalcProxy calcProxyWithLimits = new CalcProxy(new Validator(-10, 10), _calculator);
            try
            {
                calcProxyWithLimits.BinaryOperation(_calculator.Add, -30, -50);
                Assert.Fail("This should fail as arguments exceed both limits");
            }
            catch (OverflowException)
            {

                // Ok, this works
            }
        }
        [TestMethod]
        public void ValidateResultExceedingUpperLimit()
        {
            _calculator = new Calculator();
            CalcProxy calcProxyWithLimits = new CalcProxy(new Validator(-10, 10), _calculator);
            try
            {
                calcProxyWithLimits.BinaryOperation(_calculator.Add, 10, 10);
                Assert.Fail("This should fail as result exceed upper limit");
            }
            catch (OverflowException)
            {

                // Ok, this works
            }
        }
        [TestMethod]
        public void ValidateResultExceedingLowerLimit()
        {
            _calculator = new Calculator();
            CalcProxy calcProxyWithLimits = new CalcProxy(new Validator(-10, 10), _calculator);
            try
            {
                calcProxyWithLimits.BinaryOperation(_calculator.Add, -20, -1);
                Assert.Fail("This should fail as result exceed upper limit");
            }
            catch (OverflowException)
            {

                // Ok, this works
            }
        }  
    }
}
