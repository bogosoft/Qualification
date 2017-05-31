namespace Bogosoft.Qualification
{
    /// <summary>
    /// Qualify an object.
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
