using System;

namespace Bogosoft.Qualification
{
    /// <summary>Provides a means of qualifying an object.</summary>
    /// <typeparam name="T">The type to qualify.</typeparam>
    public interface IQualify<T>
    {
        /// <summary>Qualify an object.</summary>
        /// <param name="object">An object to qualify.</param>
        /// <returns>True if the given object qualifies; false otherwise.</returns>
        Boolean Qualify(T @object);
    }
}