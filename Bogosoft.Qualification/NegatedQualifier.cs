using System;

namespace Bogosoft.Qualification
{
    class NegatedQualifier<T> : IQualify<T>
    {
        Qualifier<T> qualifier;

        internal NegatedQualifier(Qualifier<T> qualifier)
        {
            this.qualifier = qualifier;
        }

        public Boolean Qualify(T graph)
        {
            return false == qualifier.Invoke(graph);
        }
    }
}