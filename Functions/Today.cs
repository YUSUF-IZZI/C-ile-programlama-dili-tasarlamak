

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiSystems.Interpreter
{
    /// <summary>
    /// Returns today's date.
    /// Usage: Today()
    /// </summary>
    public class Today : Function
    {
        public override string Name
        {
            get
            {
                return "TODAY";
            }
        }

        public override Literal Execute(IConstruct[] arguments)
        {
            base.EnsureArgumentCountIs(arguments, 0);

            return new DateTime(System.DateTime.Today);
        }
    }
}
