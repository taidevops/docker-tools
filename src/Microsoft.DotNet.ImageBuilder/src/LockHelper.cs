// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.DotNet.ImageBuilder
{
    public static class LockHelper
    {
        public static TValue DoubleCheckedLockLookup<TKey, TValue>(
            object lockObj, IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> getValue, Func<TValue, bool> addToDictionary = null)
        {
            if (!dictionary.TryGetValue(key, out TValue value))
            {
                value = getValue();
                if (addToDictionary is null || addToDictionary(value))
                {
                    dictionary.Add(key, value);
                }
            }

            return value;
        }
    }
}
