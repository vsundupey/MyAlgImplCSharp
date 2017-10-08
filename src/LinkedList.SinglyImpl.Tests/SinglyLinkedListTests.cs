using System;
using System.Threading.Tasks;
using Xunit;

namespace LinkedList.SinglyImpl.Tests
{
    public class SinglyLinkedListTests
    {
        [Fact]
        public void Add_ShouldBe_Ok()
        {            
            var linkedList = new SinglyLinkedList<string>();
            
            linkedList.Add("value1");
            linkedList.Add("value2");
            linkedList.Add("value3");
            
            Assert.Equal(3, linkedList.Count);
        }
        
        [Fact]
        public void AddFont_ShouldBe_Ok()
        {
            var value = "value4";
            var linkedList = new SinglyLinkedList<string>();
            
            linkedList.Add("value1");
            linkedList.Add("value2");
            linkedList.Add("value3");
            linkedList.AddFront(value);

            Assert.Equal(value, linkedList.First);
        }
        
        
        [Fact]
        public void Insert_ShouldBe_Ok()
        {
            var value = "insertedValue";
            int indexForInsert = 3;
            var linkedList = new SinglyLinkedList<string>();
            
            linkedList.Add("value1");
            linkedList.Add("value2");
            linkedList.Add("value3");
            linkedList.Add("value4");
            linkedList.Add("value5");
            linkedList.Add("value6");
            linkedList.Insert(indexForInsert, value);    
            linkedList.SetCurrent(indexForInsert);

            Assert.Equal(value, linkedList.Current);
        }
        
        [Fact]
        public void Insert_Should_Throw_Exception()
        {
            var value = "insertedValue";
            int indexForInsert = 5;
            var linkedList = new SinglyLinkedList<string>();
            
            linkedList.Add("value1");

            Assert.Throws<IndexOutOfRangeException>(() => linkedList.Insert(indexForInsert, value));
        }
        
        [Fact]
        public void Remove_ShouldBe_Ok()
        {            
            var linkedList = new SinglyLinkedList<string>();
            
            linkedList.Add("value1");
            linkedList.Add("value2");
            linkedList.Add("value3");
            
            linkedList.Remove();
            
            Assert.Equal(2, linkedList.Count);
        }
    }
}