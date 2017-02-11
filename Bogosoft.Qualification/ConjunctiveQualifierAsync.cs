﻿using System.Threading;
using System.Threading.Tasks;

namespace Bogosoft.Qualification
{
    class ConjunctiveQualifierAsync<T> : IQualifyAsync<T>
    {
        IQualifyAsync<T> left, right;

        internal ConjunctiveQualifierAsync(IQualifyAsync<T> left, IQualifyAsync<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public async Task<bool> QualifyAsync(T @object, CancellationToken token)
        {
            return await left.QualifyAsync(@object, token) && await right.QualifyAsync(@object, token);
        }
    }
}