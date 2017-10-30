namespace Bogosoft.Qualification
{
    class ConjunctiveQualifier<T> : IQualify<T>
    {
        Qualifier<T> left, right;

        internal ConjunctiveQualifier(Qualifier<T> left, Qualifier<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public bool Qualify(T graph)
        {
            return left.Invoke(graph) && right.Invoke(graph);
        }
    }
}