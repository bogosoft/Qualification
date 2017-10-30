using System.Threading;
using System.Threading.Tasks;

namespace Bogosoft.Qualification
{
    class ConjunctiveQualifierAsync<T> : IQualifyAsync<T>
    {
        AsyncQualifier<T> left, right;

        internal ConjunctiveQualifierAsync(AsyncQualifier<T> left, AsyncQualifier<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public async Task<bool> QualifyAsync(T @object, CancellationToken token)
        {
            return await left.Invoke(@object, token).ConfigureAwait(false)
                && await right.Invoke(@object, token).ConfigureAwait(false);
        }
    }
}