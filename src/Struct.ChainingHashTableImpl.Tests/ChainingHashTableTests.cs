using System;
using Xunit;

namespace Struct.ChainingHashTableImpl.Tests
{
    public class ChainingHashTableTests
    {
        private ChainingHashTable _table;

        public ChainingHashTableTests()
        {
            _table = new ChainingHashTable();
        }

        [Fact]
        public void AddShouldBeOk()
        {           
            var keyForGet45 = 45;
            var valueForGet45 = "Hello45";
            
            _table.Add(5, "Hello5");
            _table.Add(3, "Hello3");
            _table.Add(keyForGet45, valueForGet45);
            _table.Add(4, "Hello4");
           
            Assert.True(_table.ContainsKey(keyForGet45));
        }
        
        [Fact]
        public void ContainsKeyShouldBeFalse()
        {                      
            _table.Add(5, "Hello5");
            _table.Add(3, "Hello3");
            _table.Add(4, "Hello4");
           
            Assert.False(_table.ContainsKey(2));
        }
        
        [Fact]
        public void RemoveShouldBeOk()
        {           
            var keyForGet45 = 45;
            var valueForGet45 = "Hello45";
            
            _table.Add(5, "Hello5");
            _table.Add(3, "Hello3");
            _table.Add(keyForGet45, valueForGet45);
            _table.Add(4, "Hello4");
           
            _table.Remove(keyForGet45);
            Assert.False(_table.ContainsKey(keyForGet45));
        }
               
        [Fact]
        public void GetValueUsingKeyShouldBeOk()
        {
            var keyForGet45 = 45;
            var valueForGet45 = "Hello45";
            
            _table.Add(5, "Hello5");
            _table.Add(3, "Hello3");
            _table.Add(keyForGet45, valueForGet45);
            _table.Add(4, "Hello4");

            var result = _table[keyForGet45];
            Assert.Equal(valueForGet45, result);
        }
    }
}