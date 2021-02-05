
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiSystems.Interpreter
{
    /// <summary>
    /// Returns an array from a list of items.
    /// Usage: Array(item1, item2, ...)
    /// Example: Array(1, 2, 3)
    /// </summary>
    public class ArrayFunction : Function
    {
        public override string Name
        {
            get
            {
                return "Array";
            }
        }

        public override Literal Execute(IConstruct[] arguments)
        {
            base.EnsureArgumentCountIsAtLeast(arguments, 1);
            
            return new Array(arguments.Select(argument => argument.Transform()).ToArray());
        }
    }
}
