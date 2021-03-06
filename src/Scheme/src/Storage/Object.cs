using System;

namespace Scheme.Storage
{
    internal abstract class Object
    {
        public abstract override string ToString();
        public abstract Object Evaluate(Environment environment);
    }
}