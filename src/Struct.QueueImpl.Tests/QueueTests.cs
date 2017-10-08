using System;
using Xunit;

namespace Struct.QueueImpl.Tests
{
    public class QueueTests
    {
        [Fact]
        public void Peek_ShouldBe_Ok()
        {
            var queue = new MyQueue<string>();
            var first = "value1";
            
            queue.Add(first);
            queue.Add("value2");
            queue.Add("value3");
            
            Assert.Equal(first, queue.Peek());
        }
        
        [Fact]
        public void Peek_Should_Throw_NullException()
        {
            var queue = new MyQueue<string>();
            
            Assert.Throws<NullReferenceException>(() => queue.Peek());
        }
        
        [Fact]
        public void Remove_ShouldBe_Ok()
        {
            var queue = new MyQueue<string>();
            var first = "value1";
            
            queue.Add(first);
            queue.Add("value2");
            queue.Add("value3");
            
            var result = queue.Remove();
            
            Assert.Equal(first, result); // Dequeue element
            Assert.NotEqual(first, queue.Peek()); // check that element removed
        }
    }
}