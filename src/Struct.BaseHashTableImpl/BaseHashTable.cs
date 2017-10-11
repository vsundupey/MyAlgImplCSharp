using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Struct.BaseHashTableImpl
{
    public interface IMyHashTable
    {
        /// <summary>
        /// Indexer for access using key
        /// </summary>
        /// <param name="key"></param>
        object this[object key] { get; }

        /// <summary>
        /// Add new key/value pair
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Add(object key, object value);

        /// <summary>
        /// Get value using key, returns 'null' if not found
        /// </summary>
        /// <param name="key"></param>
        /// <returns>value, if not found throw KeyNotFoundException</returns>
        object GetValue(object key);

        /// <summary>
        /// Check for existing key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True of exist</returns>
        bool ContainsKey(object key);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        void Remove(object key);
    }

    public abstract class BaseHashTable
    {
        public object this[object key]
        {
            get
            {
                try
                {
                    return GetValue(key);
                }
                catch (KeyNotFoundException e)
                {
                    return null;
                }
            }
        }


        public abstract object GetValue(object key);

        protected class HashEntry
        {
            public readonly object Key;
            public readonly object Value;

            public HashEntry(object key, object value)
            {
                Key = key;
                Value = value;
            }
        }

        protected class LinkedHashEntry : HashEntry
        {
            public LinkedHashEntry Next { get; set; }
            
            public LinkedHashEntry(object key, object value) : base(key, value)
            {
            }
            
        }        
    }
}