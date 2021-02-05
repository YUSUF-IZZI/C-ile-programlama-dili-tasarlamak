

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiSystems.Interpreter
{
    /// <summary>
    /// Logical Or operator.
    /// Usage: booleanValue OR booleanValue
    /// Example: true OR false
    /// </summary>
    public class OrOperator : Operator
    {
        public OrOperator()
        {
        }

        /// <summary>
        /// Non-zero arguments are considered true.
        /// </summary>
        internal override Literal Execute(IConstruct argument1, IConstruct argument2)
        {
            return base.GetTransformedConstruct<Boolean>(argument1) || base.GetTransformedConstruct<Boolean>(argument2);
        }

        public override string Token
        {
            get
            {
                return "OR";
            }
        }
    }
}
