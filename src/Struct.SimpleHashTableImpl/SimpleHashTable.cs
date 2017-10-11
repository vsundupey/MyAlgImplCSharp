using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Struct.BaseHashTableImpl;

namespace Struct.SimpleHashTableImpl
{
    /// <summary>
    /// Simple hash table(Fixed size). It uses simple hash function. 
    /// Collisions are resolved using linear probing (open addressing strategy)
    /// This example clearly shows the basics of hashing technique.
    /// </summary>
    public class SimpleHashTable : BaseHashTable, IMyHashTable
    {
        private readonly int _size = 10;
        private readonly HashEntry[] _table;

        public SimpleHashTable()
        {
            _table = new HashEntry[_size];
        }

        public SimpleHashTable(int size)
        {
            _size = size;
            _table = new HashEntry[_size];
        }

        public override object GetValue(object key)
        {
            var hash = GetHash(key, new KeyNotFoundException($"Key {key} not found"));

            return _table[hash].Value;
        }

        public bool ContainsKey(object key)
        {
            try
            {
                var hash = GetHash(key, new KeyNotFoundException($"Key {key} not found"));

                if(_table[hash] == null) return false;

                return _table[hash].Key.Equals(key);
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public void Remove(object key)
        {
            var hash = GetHash(key, new KeyNotFoundException($"Key {key} not found"));
            _table[hash] = null;
        }

        public void Add(object key, object value)
        {
            var hash = GetHash(key, new OverflowException($"Table max size {_size} is exceeded"));

            _table[hash] = new HashEntry(key, value);
        }

        /// <summary>
        /// Search index for key hash
        /// </summary>
        /// <param name="key"></param>
        /// <param name="exception">Use custom exception for different cases</param>
        /// <returns>Index for key location in array</returns>
        /// <exception cref="Exception"></exception>
        private int GetHash(object key, Exception exception = null)
        {
            int currentIndex = 0;
            var hash = ((int) key % _size);

            while (_table[hash] != null && !_table[hash].Key.Equals(key))
            {
                hash = (hash + 1) % _size;
                currentIndex++;

                if (currentIndex > _size)
                    throw exception;
            }

            return hash;
        }
    }
}