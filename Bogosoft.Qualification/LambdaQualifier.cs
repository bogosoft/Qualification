using System;

namespace Bogosoft.Qualification
{
    /// <summary>A qualification strategy that wraps an anonymous function.</summary>
    /// <typeparam name="T">The type of object to qualify.</typeparam>
    public sealed class LambdaQualifier<T> : IQualify<T>
    {
        private Func<T, Boolean> lambda;

        /// <summary>Create a new qualifier instance with a given anonymous function.</summary>
        /// <param name="lambda">An anonymous function.</param>
        public LambdaQualifier(Func<T, Boolean> lambda)
        {
            this.lambda = lambda;
        }

        /// <summary>Qualify an object.</summary>
        /// <param name="object">An object to qualify.</param>
        /// <returns>True if the given object qualifies; false otherwise.</returns>
        public Boolean Qualify(T @object)
        {
            return this.lambda.Invoke(@object);
        }
    }
}