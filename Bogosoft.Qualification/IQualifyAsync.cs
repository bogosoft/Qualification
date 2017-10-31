using System.Threading;
using System.Threading.Tasks;

namespace Bogosoft.Qualification
{
    /// <summary>
    /// Indicates that an implementation is capable of qualifying an object asyncrhonously.
    /// </summary>
    /// <typeparam name="T">The type of the object to be qualified.</typeparam>
    public interface IQualifyAsync<in T>
    {
        /// <summary>
        /// Qualify an object.
        /// </summary>
        /// <param name="object">An object to be qualified.</param>
        /// <param name="token">A <see cref="CancellationToken"/> object.</param>
        /// <returns>
        /// A value indicating whether or not the given object is qualified.
        /// </returns>
        Task<bool> QualifyAsync(T @object, CancellationToken token);
    }
}