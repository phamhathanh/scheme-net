using System;

namespace Scheme.Storage
{
    internal sealed class String : Atom
    {
        private readonly string value;
        
        public String(string value)
        {
            this.value = value;
        }

        public override sealed Object Evaluate(Environment environment)
            => this;

        public override sealed string ToString()
            => $"\"{value}\"";
    }
}