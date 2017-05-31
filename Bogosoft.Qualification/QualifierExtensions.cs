using System;

namespace Bogosoft.Qualification
{
    /// <summary>Extensions for the <see cref="IQualify{T}"/> interface.</summary>
    public static class QualifierExtensions
    {
        /// <summary>Add a conjunctive (AND) qualifier to the current qualifier.</summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="left">The current qualifier.</param>
        /// <param name="right">A qualifier to serve as the right-hand side of the operation.</param>
        /// <returns>
        /// A conjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static IQualify<T> And<T>(this IQualify<T> left, IQualify<T> right)
        {
            return new ConjunctiveQualifier<T>(left, right);
        }

        /// <summary>Add a conjunctive (AND) qualifier to the current qualifier.</summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="qualifier">The current qualifier.</param>
        /// <param name="delegate">
        /// A qualifier (in the form of a delegate) to serve as the right-hand side of the operation.
        /// </param>
        /// <returns>
        /// A conjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static IQualify<T> And<T>(this IQualify<T> qualifier, Qualifier<T> @delegate)
        {
            return new ConjunctiveQualifier<T>(qualifier, new DelegateQualifier<T>(@delegate));
        }

        /// <summary>Negate the current qualifier.</summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="qualifier">The current qualifier.</param>
        /// <returns>A negation of the current qualifier.</returns>
        public static IQualify<T> Negate<T>(this IQualify<T> qualifier)
        {
            return new NegatedQualifier<T>(qualifier);
        }

        /// <summary>Add a disjunctive (OR) qualifier to the current qualifier.</summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="left">The current qualifier.</param>
        /// <param name="right">A qualifier to serve as the right-hand side of the operation.</param>
        /// <returns>
        /// A disjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static IQualify<T> Or<T>(this IQualify<T> left, IQualify<T> right)
        {
            return new DisjunctiveQualifier<T>(left, right);
        }

        /// <summary>Add a disjunctive (OR) qualifier to the current qualifier.</summary>
        /// <typeparam name="T">The type of the object to qualify.</typeparam>
        /// <param name="qualifier">The current qualifier.</param>
        /// <param name="delegate">
        /// A constraint (in the form of a delegate) to serve as the right-hand side of the operation.
        /// </param>
        /// <returns>
        /// A disjunctive qualifier consisting of the current qualifier as the left-hand side
        /// of the operation and an additional qualifier as the right-hand side.
        /// </returns>
        public static IQualify<T> Or<T>(this IQualify<T> qualifier, Qualifier<T> @delegate)
        {
            return new DisjunctiveQualifier<T>(qualifier, new DelegateQualifier<T>(@delegate));
        }
    }
}