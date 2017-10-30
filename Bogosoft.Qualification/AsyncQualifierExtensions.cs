using System.Threading;
using System.Threading.Tasks;

namespace Bogosoft.Qualification
{
    /// <summary>
    /// Extended functionality for the <see cref="AsyncQualifier{T}"/> contract.
    /// </summary>
    public static class AsyncQualifierExtensions
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
        public static AsyncQualifier<T> And<T>(this AsyncQualifier<T> current, IQualifyAsync<T> qualifier)
        {
            return new ConjunctiveQualifierAsync<T>(current, qualifier.QualifyAsync).QualifyAsync;
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
        public static AsyncQualifier<T> And<T>(this AsyncQualifier<T> current, AsyncQualifier<T> qualifier)
        {
            return new ConjunctiveQualifierAsync<T>(current, qualifier).QualifyAsync;
        }

        /// <summary>
        /// Negate the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="current">The current qualifier.</param>
        /// <returns>A negation of the current qualifier.</returns>
        public static AsyncQualifier<T> Negate<T>(this AsyncQualifier<T> current)
        {
            return new NegatedQualifierAsync<T>(current).QualifyAsync;
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
        public static AsyncQualifier<T> Or<T>(this AsyncQualifier<T> current, IQualifyAsync<T> qualifier)
        {
            return new DisjunctiveQualifierAsync<T>(current, qualifier.QualifyAsync).QualifyAsync;
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
        public static AsyncQualifier<T> Or<T>(this AsyncQualifier<T> current, AsyncQualifier<T> qualifier)
        {
            return new DisjunctiveQualifierAsync<T>(current, qualifier).QualifyAsync;
        }
        /// <summary>
        /// Qualify an object.
        /// </summary>
        /// <typeparam name="T">The type of the objects to qualify.</typeparam>
        /// <param name="current">The current <see cref="AsyncQualifier{T}"/> implementation.</param>
        /// <param name="object">An object to qualify.</param>
        /// <returns>
        /// A value indicating whether or not object is qualified.
        /// </returns>
        public static Task<bool> QualifyAsync<T>(this AsyncQualifier<T> current, T @object)
        {
            return current.Invoke(@object, CancellationToken.None);
        }

        /// <summary>Qualify an object.</summary>
        /// <typeparam name="T">The type of the objects to qualify.</typeparam>
        /// <param name="current">The current <see cref="AsyncQualifier{T}"/> implementation.</param>
        /// <param name="object">An object to qualify.</param>
        /// <param name="token">A <see cref="CancellationToken"/> object.</param>
        /// <returns>
        /// A value indicating whether or not object is qualified.
        /// </returns>
        public static Task<bool> QualifyAsync<T>(
            this AsyncQualifier<T> current,
            T @object,
            CancellationToken token
            )
        {
            return current.Invoke(@object, token);
        }
    }
}