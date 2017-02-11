using System.Collections.Generic;

namespace Bogosoft.Qualification
{
    /// <summary>
    /// Extended functionality for types implementing <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Filter the current sequence for elements that match a given predicate.
        /// </summary>
        /// <typeparam name="T">The type of the items in the sequence.</typeparam>
        /// <param name="source">The current sequence of elements.</param>
        /// <param name="predicate">
        /// A condition to filter the sequence by.
        /// </param>
        /// <returns>
        /// A sequence of elements filtered by the given predicate.
        /// </returns>
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, IQualify<T> predicate)
        {
            foreach(var x in source)
            {
                if (predicate.Qualify(x))
                {
                    yield return x;
                }
            }
        }
    }
}