

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiSystems.Interpreter
{
    /// <summary>
    /// Divides numeric values.
    /// Usage: numericValue / numericValue
    /// Example: 1 / 2
    /// </summary>
    public class DivideOperator : Operator
    {
        public DivideOperator()
        {
        }

        internal override Literal Execute(IConstruct argument1, IConstruct argument2)
        {
            var argument2Value = base.GetTransformedConstruct<Number>(argument2);

            if (argument2Value == 0)
                throw new DivideByZeroException(argument2.ToString());

            return base.GetTransformedConstruct<Number>(argument1) / argument2Value;
        }

        public override string Token
        {
            get
            {
                return "/";
            }
        }
    }
}
