namespace Bogosoft.Qualification
{
    /// <summary>
    /// Extended functionality for the <see cref="IQualify{T}"/> contract.
    /// </summary>
    public static class IQualifyExtensions
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
        public static IQualify<T> And<T>(this IQualify<T> current, IQualify<T> qualifier)
        {
            return new ConjunctiveQualifier<T>(current.Qualify, qualifier.Qualify);
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
        public static IQualify<T> And<T>(this IQualify<T> current, Qualifier<T> qualifier)
        {
            return new ConjunctiveQualifier<T>(current.Qualify, qualifier);
        }

        /// <summary>
        /// Negate the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <returns>A negation of the current qualifier.</returns>
        public static IQualify<T> Negate<T>(this IQualify<T> current)
        {
            return new NegatedQualifier<T>(current.Qualify);
        }

        /// <summary>
        /// Negate the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <returns>A negation of the current qualifier.</returns>
        public static IQualify<T> Negate<T>(this Qualifier<T> current)
        {
            return new NegatedQualifier<T>(current);
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
        public static IQualify<T> Or<T>(this IQualify<T> current, IQualify<T> qualifier)
        {
            return new DisjunctiveQualifier<T>(current.Qualify, qualifier.Qualify);
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
        public static IQualify<T> Or<T>(this IQualify<T> current, Qualifier<T> qualifier)
        {
            return new DisjunctiveQualifier<T>(current.Qualify, qualifier);
        }
    }
}