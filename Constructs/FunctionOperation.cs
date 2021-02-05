
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiSystems.Interpreter
{
    
    public class FunctionOperation : IConstruct
    {
        private Function function;
        private IConstruct[] arguments = null;

        public FunctionOperation(Function function, IConstruct[] arguments)
        {
            if (function == null)
                throw new ArgumentNullException();

            this.function = function;
            this.arguments = arguments;
        }
        
        Literal IConstruct.Transform()
        {
          

            return function.Execute(this.arguments);
        }

        
        public Function Function
        {
            get
            {
                return this.function;
            }
        }

        
        public IConstruct[] Arguments
        {
            get
            {
                return this.arguments;
            }
        }

        public override string ToString()
        {
            return this.function.ToString();
        }
    }
}
