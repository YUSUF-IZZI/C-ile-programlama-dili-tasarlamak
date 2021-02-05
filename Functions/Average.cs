

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiSystems.Interpreter
{
    /// <summary>
    /// Accepts one argument of type Array containing objects of type Number.
    /// Usage: AVG(array)
    /// Example: Avg(Array(1, 2, 3))
    /// </summary>
    public class Average : Function
    {
        public override string Name
        {
            get
            {
                return "AVG";
            }
        }

        public override Literal Execute(IConstruct[] arguments)
        {
            base.EnsureArgumentCountIs(arguments, 1);

            return new Number(base.GetTransformedArgumentDecimalArray(arguments, argumentIndex:0).Average());
        }
    }
}
