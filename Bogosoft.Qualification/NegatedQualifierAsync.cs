using System.Threading;
using System.Threading.Tasks;

namespace Bogosoft.Qualification
{
    class NegatedQualifierAsync<T> : IQualifyAsync<T>
    {
        IQualifyAsync<T> qualifier;

        internal NegatedQualifierAsync(IQualifyAsync<T> qualifier)
        {
            this.qualifier = qualifier;
        }

        public async Task<bool> QualifyAsync(T @object, CancellationToken token)
        {
            return false == await qualifier.QualifyAsync(@object, token);
        }
    }
}