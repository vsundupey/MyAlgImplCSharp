using System;
using Xunit;

namespace Struct.SimpleHashTableImpl.Tests
{
    public class SimpleHashTableTests
    {
        private SimpleHashTable _table;

        public SimpleHashTableTests()
        {
            _table = new SimpleHashTable();
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
            var keyForGet45 = 45;
            var valueForGet45 = "Hello45";
            
            _table.Add(5, "Hello5");
            _table.Add(3, "Hello3");
            _table.Add(keyForGet45, valueForGet45);
            _table.Add(4, "Hello4");
           
            Assert.True(_table.ContainsKey(2));
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
            Assert.True(_table.ContainsKey(keyForGet45));
        }
        
        [Fact]
        public void AddShouldThrowOverflowException()
        {           
            var keyForGet45 = 45;
            var valueForGet45 = "Hello45";
            
            _table = new SimpleHashTable(3);
            
            _table.Add(5, "Hello5");
            _table.Add(3, "Hello3");
            _table.Add(keyForGet45, valueForGet45);
            Assert.Throws<OverflowException>(() => _table.Add(4, "Hello4"));
           
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