
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiSystems.Interpreter
{
    /// <summary>
    /// Compares two numeric or datetime values.
    /// Usage: 
    ///   numericValue &lt;= numericValue
    ///   dateTime &lt;= dateTime
    /// Examples:
    ///   1 &lt;= 2
    ///   #2000-01-02# &lt;= #2000-01-0
    /// </summary>
    public class LessThanOrEqualToOperator : Operator
    {
        public LessThanOrEqualToOperator()
        {
        }

        internal override Literal Execute(IConstruct argument1, IConstruct argument2)
        {
            var argument1Transformed = base.GetTransformedConstruct<Literal>(argument1);
            var argument2Transformed = base.GetTransformedConstruct<Literal>(argument2);

            if (argument1Transformed is Number && argument2Transformed is Number)
                return ((Number)argument1Transformed) <= ((Number)argument2Transformed);
            else if (argument1Transformed is DateTime && argument2Transformed is DateTime)
                return ((DateTime)argument1Transformed) <= ((DateTime)argument2Transformed);
            else
                throw new InvalidOperationException(String.Format("Less than or equal to operator requires arguments of type Number or DateTime. Argument types are {0} {1}.", argument1Transformed.GetType().Name, argument2Transformed.GetType().Name));
        }

        public override string Token
        {
            get 
            {
                return "<=";
            }
        }
    }
}
