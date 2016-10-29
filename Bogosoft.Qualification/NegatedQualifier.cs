using System;

namespace Bogosoft.Qualification
{
    internal sealed class NegatedQualifier<T> : IQualify<T>
    {
        private IQualify<T> constraint;

        internal NegatedQualifier(IQualify<T> constraint)
        {
            this.constraint = constraint;
        }

        public Boolean Qualify(T graph)
        {
            return false == this.constraint.Qualify(graph);
        }
    }
}