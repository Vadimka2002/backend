using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        private static char[] operations = new char[]
        {
            '+',
            '-',
            '*',
            '/'
        };

        private static dynamic Add(dynamic left, dynamic right)
        {
            return left + right;
        }

        private static dynamic Substract(dynamic left, dynamic right)
        {
            return left - right;
        }

        private static dynamic Multiply(dynamic left, dynamic right)
        {
            return left * right;
        }

        private static dynamic Divide(dynamic left, dynamic right)
        {
            if (right == 0)
            {
                throw new DivideByZeroException("You can't divide by zero!");
            }

            return (decimal)left / right;
        }

        private static int FindOperation(string expression)
        {
            foreach (var oper in operations)
            {
                if (expression.Contains(oper))
                {
                    return expression.IndexOf(oper);
                }
            }

            throw new InvalidDataException("No operation found!");
        }

        private static dynamic ParseOperand(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("One of the operands not found!");
            }

            if (value.Contains('.'))
            {
                decimal operand;
                if (!decimal.TryParse(value, out operand))
                {
                    throw new InvalidDataException("Operand parsing error");
                }
                return operand;
            }
            else
            {
                int operand;
                if (!int.TryParse(value, out operand))
                {
                    throw new InvalidDataException("Operand parsing error");
                }
                return operand;
            }
        }

        public static dynamic Calculate(string input)
        {
            int operationIndex = FindOperation(input);

            dynamic leftOperand = ParseOperand(input.Substring(0, operationIndex));
            dynamic rightOperand = ParseOperand(input.Substring(operationIndex + 1));

            switch (input[operationIndex])
            {
                case '+': return Add(leftOperand, rightOperand);
                case '-': return Substract(leftOperand, rightOperand);
                case '*': return Multiply(leftOperand, rightOperand);
                case '/': return Divide(leftOperand, rightOperand);
            }

            throw new InvalidDataException("No operation found");
        }
    }
}
