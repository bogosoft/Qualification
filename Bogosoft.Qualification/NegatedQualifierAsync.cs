using System.Threading;
using System.Threading.Tasks;

namespace Bogosoft.Qualification
{
    class NegatedQualifierAsync<T> : IQualifyAsync<T>
    {
        AsyncQualifier<T> qualifier;

        internal NegatedQualifierAsync(AsyncQualifier<T> qualifier)
        {
            this.qualifier = qualifier;
        }

        public async Task<bool> QualifyAsync(T @object, CancellationToken token)
        {
            return false == await qualifier.Invoke(@object, token).ConfigureAwait(false);
        }
    }
}