

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiSystems.Interpreter
{
    
    public class Operation : IConstruct
    {
        private const int PrecedenceUndefined = -1;

        private IConstruct leftValue;
        private Operator @operator;
        private IConstruct rightValue;
        private int precedence = PrecedenceUndefined;

        internal Operation()
        {
        }

        
        public Operation(IConstruct leftValue, Operator operation, IConstruct rightValue)
        {
            if (leftValue == null || rightValue == null || operation == null)
                throw new ArgumentNullException();

            this.leftValue = leftValue;
            this.@operator = operation;
            this.rightValue = rightValue;
        }

        Literal IConstruct.Transform ()
        {
            return this.@operator.Execute(this.leftValue, this.rightValue);
        }

        
        internal int Precedence
        {
            get
            {
                return this.precedence;
            }

            set
            {
                if (value <= PrecedenceUndefined)
                    throw new ArgumentException(value.ToString());

                this.precedence = value;
            }
        }

        internal bool PrecedenceIsSet
        {
            get
            {
                return this.precedence != PrecedenceUndefined;
            }
        }

        
        public IConstruct LeftValue
        {
            get
            {
                return this.leftValue;
            }

            internal set
            {
                if (value == null)
                    throw new ArgumentNullException();

                this.leftValue = value;
            }
        }

        
        public Operator Operator
        {
            get
            {
                return this.@operator;
            }

            internal set
            {
                if (value == null)
                    throw new ArgumentNullException();

                this.@operator = value;
            }
        }

       
        public IConstruct RightValue
        {
            get
            {
                return this.rightValue;
            }

            internal set
            {
                if (value == null)
                    throw new ArgumentNullException();

                this.rightValue = value;
            }
        }
        
        public override string ToString()
        {
            return this.leftValue.ToString() + " " + this.@operator.Token + " " + this.rightValue.ToString();
        }


//      /// </summary>
//        public IConstruct[] GetAllItems()
//        {
//            var items = new List<IConstruct>();
//
//            GetAllItems(items, this);
//
//            return items.ToArray();
//        }
//
//        private void GetAllItems(List<IConstruct> items, IConstruct value)
//        {
//            items.Add(value);
//
//            if (value is Operation)
//            {
//                GetAllItems(items, ((Operation)value).LeftValue);
//                GetAllItems(items, ((Operation)value).RightValue);
//            }
//        }
    }
}
