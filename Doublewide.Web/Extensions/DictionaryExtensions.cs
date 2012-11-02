using System.Collections.Generic;

namespace Doublewide.Web.Extensions
{
    public static class DictionaryExtensions
    {
        public static bool TryGetTypedValue<TKey, TValue, TActual>(this IDictionary<TKey, TValue> dictionary, TKey key, out TActual value) 
            where TActual : TValue
        {
            TValue rawValue;
            if (dictionary.TryGetValue(key, out rawValue))
            {
                value = (TActual)rawValue;
                return true;
            }

            value = default(TActual);
            return false;
        }
    }
}