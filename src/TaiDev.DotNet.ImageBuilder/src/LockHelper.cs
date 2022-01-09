
namespace TaiDev.DotNet.ImageBuilder;

#nullable disable
public static class LockHelper
{
    public static TValue DoubleCheckedLockLookup<TKey, TValue>(
            object lockObj, IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> getValue, Func<TValue, bool> addToDictionary = null)
    {
        if (!dictionary.TryGetValue(key, out TValue value))
        {
            lock (lockObj)
            {
                if (!dictionary.TryGetValue(key, out value))
                {
                    value = getValue();
                    if (addToDictionary is null || addToDictionary(value))
                    {
                        dictionary.Add(key, value);
                    }
                }
            }
        }

        return value;
    }
}
#nullable enable
