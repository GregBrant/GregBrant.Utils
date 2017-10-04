using System;
using System.Collections.Generic;

namespace GregBrant.Utils.Collections
{
    public class SparseDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private readonly Func<TKey, TValue> _valueGetter;

        public SparseDictionary() : this(_ => default(TValue))
        {

        }

        public SparseDictionary(Func<TKey, TValue> valueGetter)
        {
            _valueGetter = valueGetter;
        }

        public new TValue this[TKey key]
        {
            get
            {
                if (ContainsKey(key) == false)
                {
                    base[key] = _valueGetter(key);
                }

                return base[key];
            }
            set { base[key] = value; }
        }
    }
}
