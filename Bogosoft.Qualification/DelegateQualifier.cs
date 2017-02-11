using System;

namespace Bogosoft.Qualification
{
    /// <summary>
    /// A qualification strategy that wraps a delegate.
    /// </summary>
    /// <typeparam name="T">The type of object to qualify.</typeparam>
    public sealed class DelegateQualifier<T> : IQualify<T>
    {
        private Func<T, bool> @delegate;

        /// <summary>
        /// Create a new qualifier instance with a given delegate.
        /// </summary>
        /// <param name="delegate">An anonymous function.</param>
        public DelegateQualifier(Func<T, bool> @delegate)
        {
            this.@delegate = @delegate;
        }

        /// <summary>Qualify an object.</summary>
        /// <param name="object">An object to qualify.</param>
        /// <returns>True if the given object qualifies; false otherwise.</returns>
        public bool Qualify(T @object)
        {
            return @delegate.Invoke(@object);
        }
    }
}