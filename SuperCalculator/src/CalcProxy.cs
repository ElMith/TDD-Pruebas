using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SuperCalculator
{
    public delegate int SingleBinaryOperation(int a, int b);
    class CalcProxy
    {
        private Calculator _calculator;
        private Validator _validador;

        public CalcProxy(Validator validador, Calculator calculator)
        {
            _validador = validador;
            _calculator = calculator;
        }

        public int BinaryOperation(SingleBinaryOperation operation, int arg1, int arg2)
        {
            _validador.ValidateArgs(arg1, arg2);
            int result = 0;
            MethodInfo[] calcultatorMethods = _calculator.GetType().GetMethods(BindingFlags.Public |
                                              BindingFlags.Instance);
            foreach (MethodInfo method in calcultatorMethods)
            {
                if (method == operation.Method)
                {
                    result = (int)method.Invoke(_calculator, new Object[] { arg1, arg2 });
                
                }
            }
            _validador.ValidateResult(result);
            return result;
        }
    }
}
