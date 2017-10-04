using System;
using Xunit;

namespace Struct.StackImpl.Tests
{
    public class MyStackTests
    {
        [Fact]
        public void TestPush()
        {
            var myStack = new MyStack<string>();

            var value1 = "1";
            var value2 = "2";
            var value3 = "3";
          
            myStack.Push(value1);
            Assert.Equal(value1, myStack.Peek());
            
            Assert.False(myStack.IsEmpty());
            
            myStack.Push(value2);
            Assert.Equal(value2, myStack.Peek());
            
            myStack.Push(value3);
            Assert.Equal(value3, myStack.Peek());
        }
        
        [Fact]
        public void TestPop()
        {
            var myStack = new MyStack<string>();

            var value1 = "1";
            var value2 = "2";
            var value3 = "3";
          
            myStack.Push(value1);           
            myStack.Push(value2);
            myStack.Push(value3);

            Assert.Equal(value3, myStack.Pop());
            Assert.Equal(value2, myStack.Pop());
            Assert.Equal(value1, myStack.Pop());
            Assert.True(myStack.IsEmpty());
        }
    }
}