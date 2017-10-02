using System;
using Xunit;

namespace Struct.QueueImpl.Tests
{
    public class QueueTests
    {
        [Fact]
        public void Peek_ShouldBe_Ok()
        {
            var queue = new Queue<string>();
            var first = "value1";
            
            queue.Add(first);
            queue.Add("value2");
            queue.Add("value3");
            
            Assert.Equal(first, queue.Peek());
        }
        
        [Fact]
        public void Remove_ShouldBe_Ok()
        {
            var queue = new Queue<string>();
            var first = "value1";
            
            queue.Add(first);
            queue.Add("value2");
            queue.Add("value3");
            
            queue.Remove();
            
            Assert.NotEqual(first, queue.Peek());
        }
        
        [Fact]
        public void Dequeue_ShouldBe_Ok()
        {
            var queue = new Queue<string>();
            var first = "value1";
            
            queue.Add(first);
            queue.Add("value2");
            queue.Add("value3");
            
            var result = queue.Dequeue();
            
            Assert.Equal(first, result);
        }
    }
}