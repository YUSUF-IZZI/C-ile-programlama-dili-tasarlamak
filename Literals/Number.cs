

using System;
using System.ComponentModel;
using System.Text;
using HiSystems.Interpreter.Converters;

namespace HiSystems.Interpreter
{
    /// <summary>
    /// Represents an immutable numeric value.
    /// </summary>
    [TypeConverter(typeof(NumberTypeConverter))]
    public class Number : Literal
    {
        private decimal value;

        public Number(decimal value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
        
        public string ToString(string format)
        {
            return value.ToString(format);
        }
        
        public static implicit operator decimal(Number number)
        {
            return number.value;
        }
        
        public static implicit operator double(Number number)
        {
            return (double)number.value;
        }

        public static implicit operator Number(decimal value)
        {
            return new Number(value);
        }
        
        public static implicit operator Number(double value)
        {
            return new Number((decimal)value);
        }
        
        public static implicit operator Number(int value)
        {
            return new Number((decimal)value);
        }

        public static Number Parse(string value)
        {
            return new Number(Decimal.Parse(value));
        }

        public static Boolean operator==(Number value1, Number value2)
        {
            return AreEqual(value1, value2);
        }
        
        public static Boolean operator!=(Number value1, Number value2)
        {
            return !AreEqual(value1, value2);
        }

        public static Number operator+(Number value1, Number value2)
        {
            return new Number(value1.value + value2.value);
        }
        
        public static Number operator-(Number value1, Number value2)
        {
            return new Number(value1.value - value2.value);
        }

        public static Number operator/(Number value1, Number value2)
        {
            return new Number(value1.value / value2.value);
        }
        
        public static Boolean operator>(Number value1, Number value2)
        {
            return new Boolean(value1.value > value2.value);
        }
        
        public static Boolean operator>=(Number value1, Number value2)
        {
            return new Boolean(value1.value >= value2.value);
        }

        public static Boolean operator<(Number value1, Number value2)
        {
            return new Boolean(value1.value < value2.value);
        }
        
        public static Boolean operator<=(Number value1, Number value2)
        {
            return new Boolean(value1.value <= value2.value);
        }
        
        public static Number operator*(Number value1, Number value2)
        {
            return new Number(value1.value * value2.value);
        }

        public static Number operator%(Number value1, Number value2)
        {
            return new Number(value1.value % value2.value);
        }

        public override bool Equals (object obj)
        {
            if (obj == null || !(obj is Number))
                return false;
            else 
                return AreEqual(this, (Number)obj);
        }
        
        private static Boolean AreEqual(Number value1, Number value2)
        {
            if (ReferenceEquals(value1, null) || ReferenceEquals(value2, null))
                return new Boolean(false);
            else
                return new Boolean(value1.value == value2.value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
