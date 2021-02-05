

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiSystems.Interpreter
{
    /// <summary>
    /// Returns the maximum numeric value from an array.
    /// Usage: Max(array)
    /// Example: Max(Array(1, 2, 3))
    /// </summary>
    public class Max : Function
    {
        public override string Name
        {
            get
            {
                return "MAX";
            }
        }

        public override Literal Execute(IConstruct[] arguments)
        {
            base.EnsureArgumentCountIs(arguments, 1);
            
            return new Number(base.GetTransformedArgumentDecimalArray(arguments, argumentIndex:0).Max());
        }
    }
}
