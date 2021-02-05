

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiSystems.Interpreter
{
    
    public class Variable : IConstruct
    {
        private string name;
        private IConstruct construct;
        
        
        public Variable(string name)
            : this(name, null)
        {
        }

        
        public Variable(string name, IConstruct value)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name");

            this.name = name;
            this.construct = value;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

      
        public IConstruct Value
        {
            get
            {
                return this.construct;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException();

                this.construct = value;
            }
        }
        
        Literal IConstruct.Transform()
        {
            if (this.construct == null)
                throw new InvalidOperationException(String.Format("Variable {0} has not been set", this.name));

            return this.construct.Transform();
        }

        public override string ToString()
        {
            return this.name + ": " + (this.construct == null ? String.Empty : this.construct.ToString());
        }
    }
}
