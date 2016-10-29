using System;

namespace Bogosoft.Qualification
{
    internal sealed class DisjunctiveQualifier<T> : IQualify<T>
    {
        private IQualify<T> left;
        private IQualify<T> right;

        internal DisjunctiveQualifier(IQualify<T> left, IQualify<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public Boolean Qualify(T graph)
        {
            return this.left.Qualify(graph) || this.right.Qualify(graph);
        }
    }
}