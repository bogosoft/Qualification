namespace Bogosoft.Qualification
{
    /// <summary>
    /// Represents the template for a method capable of qualifying objects of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to qualify.</typeparam>
    /// <param name="object">
    /// An object of the specified type to qualify.
    /// </param>
    /// <returns>
    /// A value indicating whether or not a given object is qualified.
    /// </returns>
    public delegate bool Qualifier<T>(T @object);
}
