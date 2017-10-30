namespace Bogosoft.Qualification
{
    /// <summary>Extended functionality for the <see cref="Qualifier{T}"/> contract.</summary>
    public static class QualifierExtensions
    {
        /// <summary>
        /// Add a conjunctive (AND) qualifier to the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <param name="qualifier">A qualifier to serve as the right-hand side of the operation.</param>
        /// <returns>
        /// A conjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static Qualifier<T> And<T>(this Qualifier<T> current, IQualify<T> qualifier)
        {
            return new ConjunctiveQualifier<T>(current, qualifier.Qualify).Qualify;
        }

        /// <summary>
        /// Add a conjunctive (AND) qualifier to the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <param name="qualifier">
        /// A delegate qualifier to serve as the right-hand side of the operation.
        /// </param>
        /// <returns>
        /// A conjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static Qualifier<T> And<T>(this Qualifier<T> current, Qualifier<T> qualifier)
        {
            return new ConjunctiveQualifier<T>(current, qualifier).Qualify;
        }

        /// <summary>
        /// Negate the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <returns>A negation of the current qualifier.</returns>
        public static Qualifier<T> Negate<T>(this Qualifier<T> current)
        {
            return new NegatedQualifier<T>(current).Qualify;
        }

        /// <summary>
        /// Add a disjunctive (OR) qualifier to the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <param name="qualifier">A qualifier to serve as the right-hand side of the operation.</param>
        /// <returns>
        /// A disjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static Qualifier<T> Or<T>(this Qualifier<T> current, IQualify<T> qualifier)
        {
            return new DisjunctiveQualifier<T>(current, qualifier.Qualify).Qualify;
        }

        /// <summary>
        /// Add a disjunctive (OR) qualifier to the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <param name="qualifier">
        /// A delegate qualifier to serve as the right-hand side of the operation.
        /// </param>
        /// <returns>
        /// A disjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static Qualifier<T> Or<T>(this Qualifier<T> current, Qualifier<T> qualifier)
        {
            return new DisjunctiveQualifier<T>(current, qualifier).Qualify;
        }

        /// <summary>
        /// Qualify an object.
        /// </summary>
        /// <typeparam name="T">The type of an object to qualify.</typeparam>
        /// <param name="current">The current <see cref="Qualifier{T}"/> implementation.</param>
        /// <param name="object">An object to qualify.</param>
        /// <returns>True if the given object qualifies; false otherwise.</returns>
        public static bool Qualify<T>(this Qualifier<T> current, T @object) => current.Invoke(@object);
    }
}