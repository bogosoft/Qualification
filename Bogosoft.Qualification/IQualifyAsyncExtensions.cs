using System.Threading;
using System.Threading.Tasks;

namespace Bogosoft.Qualification
{
    /// <summary>
    /// Extended functionality for the <see cref="IQualifyAsync{T}"/> contract.
    /// </summary>
    public static class IQualifyAsyncExtensions
    {
        /// <summary>
        /// Add a conjunctive (AND) qualifier to the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <param name="qualifier">A qualifier to serve as the right-hand side of the operation.</param>
        /// <returns>
        /// A conjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static IQualifyAsync<T> And<T>(this IQualifyAsync<T> current, IQualifyAsync<T> qualifier)
        {
            return new ConjunctiveQualifierAsync<T>(current.QualifyAsync, qualifier.QualifyAsync);
        }

        /// <summary>
        /// Add a conjunctive (AND) qualifier to the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <param name="qualifier">
        /// A qualifier (in the form of a delegate) to serve as the right-hand side of the operation.
        /// </param>
        /// <returns>
        /// A conjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static IQualifyAsync<T> And<T>(this IQualifyAsync<T> current, AsyncQualifier<T> qualifier)
        {
            return new ConjunctiveQualifierAsync<T>(current.QualifyAsync, qualifier);
        }

        /// <summary>
        /// Negate the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <returns>A negation of the current qualifier.</returns>
        public static IQualifyAsync<T> Negate<T>(this IQualifyAsync<T> current)
        {
            return new NegatedQualifierAsync<T>(current.QualifyAsync);
        }

        /// <summary>
        /// Negate the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <returns>A negation of the current qualifier.</returns>
        public static IQualifyAsync<T> Negate<T>(this AsyncQualifier<T> current)
        {
            return new NegatedQualifierAsync<T>(current);
        }

        /// <summary>
        /// Add a disjunctive (OR) qualifier to the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <param name="qualifier">A qualifier to serve as the right-hand side of the operation.</param>
        /// <returns>
        /// A disjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static IQualifyAsync<T> Or<T>(this IQualifyAsync<T> current, IQualifyAsync<T> qualifier)
        {
            return new DisjunctiveQualifierAsync<T>(current.QualifyAsync, qualifier.QualifyAsync);
        }

        /// <summary>
        /// Add a disjunctive (OR) qualifier to the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <param name="qualifier">
        /// A delgate qualifier to serve as the right-hand side of the operation.
        /// </param>
        /// <returns>
        /// A disjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static IQualifyAsync<T> Or<T>(this IQualifyAsync<T> current, AsyncQualifier<T> qualifier)
        {
            return new DisjunctiveQualifierAsync<T>(current.QualifyAsync, qualifier);
        }

        /// <summary>
        /// Qualify an object.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <param name="object">An object to be qualified.</param>
        /// <returns>
        /// A value indicating whether or not the given object is qualified.
        /// </returns>
        public static Task<bool> QualifyAsync<T>(this IQualifyAsync<T> current, T @object)
        {
            return current.QualifyAsync(@object, CancellationToken.None);
        }
    }
}