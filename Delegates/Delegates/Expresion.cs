using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Expresion
    {
        public Dictionary<Operation, Func<int>> operations = new Dictionary<Operation, Func<int>>();
        private int first;
        private int second;
        public Expresion(int first, int second)
        {
            this.first = first;
            this.second = second;
            
            operations.Add(Operation.Sum, Sum);
            operations.Add(Operation.Substract, Substract);
            operations.Add(Operation.Multiply, Multiply);
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
            return operations[operation]();
        }

        public enum Operation{
            Sum,
            Substract,
            Multiply
        }
    }
}
