using System.Threading;
using System.Threading.Tasks;

namespace Bogosoft.Qualification
{
    /// <summary>
    /// Extended functionality for the <see cref="IQualifyAsync{T}"/> contract.
    /// </summary>
    public static class AsyncQualifierExtensions
    {
        /// <summary>
        /// Add a conjunctive (AND) qualifier to the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="left">The current <see cref="IQualifyAsync{T}"/> implementation.</param>
        /// <param name="right">A qualifier to serve as the right-hand side of the operation.</param>
        /// <returns>
        /// A conjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static IQualifyAsync<T> And<T>(this IQualifyAsync<T> left, IQualifyAsync<T> right)
        {
            return new ConjunctiveQualifierAsync<T>(left, right);
        }

        /// <summary>
        /// Negate the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="qualifier">The current <see cref="IQualifyAsync{T}"/> implementation.</param>
        /// <returns>A negation of the current qualifier.</returns>
        public static IQualifyAsync<T> Negate<T>(this IQualifyAsync<T> qualifier)
        {
            return new NegatedQualifierAsync<T>(qualifier);
        }

        /// <summary>
        /// Add a disjunctive (OR) qualifier to the current qualifier.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="left">The current <see cref="IQualifyAsync{T}"/> implementation.</param>
        /// <param name="right">A qualifier to serve as the right-hand side of the operation.</param>
        /// <returns>
        /// A disjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static IQualifyAsync<T> Or<T>(this IQualifyAsync<T> left, IQualifyAsync<T> right)
        {
            return new DisjunctiveQualifierAsync<T>(left, right);
        }

        /// <summary>
        /// Qualify an object.
        /// </summary>
        /// <typeparam name="T">The type of the object to be qualified.</typeparam>
        /// <param name="qualifier">The current <see cref="IQualifyAsync{T}"/> implementation.</param>
        /// <param name="object">An object to be qualified.</param>
        /// <returns>
        /// A value indicating whether or not the given object is qualified.
        /// </returns>
        public static async Task<bool> QualifyAsync<T>(this IQualifyAsync<T> qualifier, T @object)
        {
            return await qualifier.QualifyAsync(@object, CancellationToken.None);
        }
    }
}