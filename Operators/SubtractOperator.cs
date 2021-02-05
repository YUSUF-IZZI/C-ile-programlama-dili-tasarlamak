

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiSystems.Interpreter
{
    /// <summary>
    /// Subtracts one numeric value from another or the number of days from a datetime value, or the difference between two dates.
    /// Usage: 
    ///   numericValue - numericValue
    ///   dateTime - numericDays
    ///   dateTime - dateTime
    /// Examples:
    ///   1 - 2
    ///   #2000-01-01# - 1
    ///   #2000-01-02# - #2000-01-01# 
    /// </summary>
    public class SubtractOperator : Operator
    {
        public SubtractOperator()
        {
        }

        internal override Literal Execute(IConstruct argument1, IConstruct argument2)
        {
            var argument1Transformed = base.GetTransformedConstruct<Literal>(argument1);
            var argument2Transformed = base.GetTransformedConstruct<Literal>(argument2);

            if (argument1Transformed is Number && argument2Transformed is Number)
                return ((Number)argument1Transformed) - ((Number)argument2Transformed);
            else if (argument1Transformed is DateTime && argument2Transformed is Number)
                return ((DateTime)argument1Transformed) - ((Number)argument2Transformed);
            else if (argument1Transformed is DateTime && argument2Transformed is DateTime)
                return (((DateTime)argument1Transformed) - ((DateTime)argument2Transformed));
            else
                throw new InvalidOperationException(String.Format("Subtract operator requires arguments of type Number or DateTime. Argument types are {0} {1}.", argument1Transformed.GetType().Name, argument2Transformed.GetType().Name));
        }

        public override string Token
        {
            get
            {
                return "-";
            }
        }
    }
}
