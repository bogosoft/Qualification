using System;

namespace Bogosoft.Qualification
{
    class DisjunctiveQualifier<T> : IQualify<T>
    {
        Qualifier<T> left,  right;

        internal DisjunctiveQualifier(Qualifier<T> left, Qualifier<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public Boolean Qualify(T graph)
        {
            return left.Invoke(graph) || right.Invoke(graph);
        }
    }
}