using System.Threading;
using System.Threading.Tasks;

namespace Bogosoft.Qualification
{
    /// <summary>
    /// Represents the template for a method capable of asynchronously qualifying
    /// objects of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of the objects to qualify.</typeparam>
    /// <param name="object">An object to qualify.</param>
    /// <param name="token">A <see cref="CancellationToken"/> object.</param>
    /// <returns>
    /// A value indicating whether or not object is qualified.
    /// </returns>
    public delegate Task<bool> AsyncQualifier<T>(T @object, CancellationToken token);
}