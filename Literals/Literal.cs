
using System;

namespace HiSystems.Interpreter
{
    /// <summary>
    /// Base class for all literals / concrete values, such as a number, boolean, string etc.
    /// </summary>
    public abstract class Literal : IConstruct
    {
        /// <summary>
        /// A literal does not need to be transformed or executed like a function or operation.
        /// So return this construct as is.
        /// </summary>
        Literal IConstruct.Transform()
        {
            return this;
        }
    }
}

