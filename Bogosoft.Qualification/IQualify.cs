namespace Bogosoft.Qualification
{
    /// <summary>
    /// Indicates that an implementation is capable of qualifying an object of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of an object to qualify.</typeparam>
    public interface IQualify<in T>
    {
        /// <summary>
        /// Qualify an object.
        /// </summary>
        /// <param name="object">An object to qualify.</param>
        /// <returns>True if the given object qualifies; false otherwise.</returns>
        bool Qualify(T @object);
    }
}