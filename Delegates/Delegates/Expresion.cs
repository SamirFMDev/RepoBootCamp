using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Expresion
    {
        public delegate int OperationDelegate();
        private int first;
        private int second;
        public Expresion(int first, int second)
        {
            this.first = first;
            this.second = second;
        }
        private int Sum()
        {
            return first + second;
        }
        private int Substract()
        {
            return first - second;
        }
        private int Multiply()
        {
            return first * second;
        }
        public int ApllyOperator(Operation operation)
        {
            OperationDelegate operationDelegate;
            switch (operation)
            {
                case Operation.Sum:
                    operationDelegate = new OperationDelegate(Sum);
                    return operationDelegate();
                case Operation.Substract:
                    operationDelegate = new OperationDelegate(Substract);
                    return operationDelegate();
                case Operation.Multiply:
                    operationDelegate = new OperationDelegate(Multiply);
                    return operationDelegate();
                default:
                    return -1;
            }
        }

        public enum Operation{
            Sum,
            Substract,
            Multiply
        }
    }
}
