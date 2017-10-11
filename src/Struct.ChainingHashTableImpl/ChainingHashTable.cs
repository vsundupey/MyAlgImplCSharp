using System;
using System.Collections.Generic;
using Struct.BaseHashTableImpl;

namespace Struct.ChainingHashTableImpl
{
    /// <summary>
    /// Hash table. Collision resolution by chaining (closed addressing)
    /// </summary>
    public class ChainingHashTable : BaseHashTable, IMyHashTable
    {
        private readonly int _size = 10;
        private readonly LinkedHashEntry[] _table;
        
        public ChainingHashTable()
        {
            _table = new LinkedHashEntry[_size];
        }

        public ChainingHashTable(int size)
        {
            _size = size;
            _table = new LinkedHashEntry[_size];
        }
        
        public void Add(object key, object value)
        {
            var hash = GetHash(key);

            if (_table[hash] == null)
            {
                _table[hash] = new LinkedHashEntry(key,value);
                return;
            }

            var tmp = new LinkedHashEntry(key, value);
            tmp.Next = _table[hash];
            _table[hash] = tmp;           
        }

        public override object GetValue(object key)
        {
            var hash = GetHash(key);

            if (_table[hash] == null)
                throw new KeyNotFoundException($"Key {key} not found");

            var currentEntry = _table[hash];
            
            while (!currentEntry.Key.Equals(key))
            {
                currentEntry = currentEntry.Next;
                
                if(currentEntry == null)
                    throw new KeyNotFoundException($"Key {key} not found");
            }

            return currentEntry.Value;
        }

        public bool ContainsKey(object key)
        {
            try
            {
                GetValue(key);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        public void Remove(object key)
        {
            var hash = GetHash(key);

            if (_table[hash] == null) return;

            LinkedHashEntry currentEntry = _table[hash];
            LinkedHashEntry prevEntry = null;
            
            while (currentEntry.Next != null && !currentEntry.Key.Equals(key))
            {
                prevEntry = currentEntry;
                currentEntry = currentEntry.Next;
                
                if(currentEntry == null) return;
            }
            
            if(currentEntry.Key.Equals(key))
            {
                if (prevEntry == null)
                    _table[hash] = currentEntry.Next;
                else
                    prevEntry.Next = currentEntry.Next;
            }         
        }

        private int GetHash(object key, Exception exception = null)
        {
            return (int)key%_size;
        }
    }
}