using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalculator
{
    class Validator
    {
        private int _upperLimit;
        private int _lowerLimit;

        public Validator(int arg1, int arg2) 
        {
            this.LowerLimit = arg1;
            this.UpperLimit = arg2;
        }
        public int LowerLimit
        {
            get { return _lowerLimit; }
            set { _lowerLimit = value; }
        }
        public int UpperLimit
        {
            get { return _upperLimit; }
            set { _upperLimit = value; }
        }  
        public bool ValidateArgs(int arg1, int arg2)
        {
            if (arg1 > _upperLimit)
                throw new OverflowException("First argument exceeds upper limit");
            if (arg2 < _lowerLimit)
                throw new OverflowException("Second argument exceeds lower limit");
            if (arg1 < _lowerLimit)
                throw new OverflowException("First argument exceeds lower limit");
            if (arg2 > _upperLimit)
                throw new OverflowException("Second argument exceeds upper limit");
            return true;
        }
        public bool ValidateResult(int arg1)
        {
            if (arg1 < _lowerLimit || arg1 > _upperLimit)
            {
                throw new OverflowException("Lower or upper limit exceeded");
            }
            return true;
        }
    }
}
