using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bogosoft.Qualification
{
    /// <summary>
    /// A delegate-backed implementation of the <see cref="IQualifyAsync{T}"/> contract.
    /// </summary>
    /// <typeparam name="T">The type of the object to be qualified.</typeparam>
    public sealed class DelegateQualifierAsync<T> : IQualifyAsync<T>
    {
        Func<T, CancellationToken, Task<bool>> @delegate;

        /// <summary>
        /// Create a new instance of the <see cref="DelegateQualifierAsync{T}"/> class.
        /// </summary>
        /// <param name="delegate">
        /// A delegate to use for qualification. Since the given delegate does not accept a
        /// <see cref="CancellationToken"/>, it will be wrapped in one that does, and
        /// <see cref="CancellationToken.ThrowIfCancellationRequested"/> will be called before the given
        /// delegate is invoked.
        /// </param>
        public DelegateQualifierAsync(Func<T, Task<bool>> @delegate)
        {
            this.@delegate = async (@object, token) =>
            {
                token.ThrowIfCancellationRequested();

                return await @delegate.Invoke(@object);
            };
        }

        /// <summary>
        /// Create a new instance of the <see cref="DelegateQualifierAsync{T}"/> class.
        /// </summary>
        /// <param name="delegate">
        /// A delegate to use for qualification.
        /// </param>
        public DelegateQualifierAsync(Func<T, CancellationToken, Task<bool>> @delegate)
        {
            this.@delegate = @delegate;
        }

        /// <summary>
        /// Qualify an object.
        /// </summary>
        /// <param name="object">An object to be qualified.</param>
        /// <param name="token">A <see cref="CancellationToken"/> object.</param>
        /// <returns>
        /// A value indicating whether or not the given object is qualified.
        /// </returns>
        public async Task<bool> QualifyAsync(T @object, CancellationToken token)
        {
            return await @delegate.Invoke(@object, token);
        }
    }
}