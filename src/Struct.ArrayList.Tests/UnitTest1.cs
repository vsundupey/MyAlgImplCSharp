using System;
using Xunit;

namespace Struct.ArrayList.Tests
{
    public class ArrayListTests
    {
        [Fact]
        public void TestAdd()
        {
            MysCustomArrayList<string> arrayList = new MysCustomArrayList<string>();

            arrayList.Add("1");
            arrayList.Add("2");
            arrayList.Add("3");
            arrayList.Add("4");

            Assert.Equal("3", arrayList[2]);
            Assert.Equal(4, arrayList.Size);

        }

        [Fact]
        public void TestCapacity()
        {
            MysCustomArrayList<string> arrayList = new MysCustomArrayList<string>();

            arrayList.Add("1");
            arrayList.Add("2");
            arrayList.Add("3");
            arrayList.Add("4");
            arrayList.Add("5");
            arrayList.Add("6");
            arrayList.Add("7");
            arrayList.Add("8");
            arrayList.Add("9");
            arrayList.Add("10");
            arrayList.Add("11");

            Assert.True(arrayList.Capacity > 10);
        }

        [Fact]
        public void TestInsertAt()
        {
            MysCustomArrayList<string> arrayList = new MysCustomArrayList<string>();

            arrayList.Add("1");
            arrayList.Add("2");
            arrayList.Add("3");
            arrayList.Add("4");
            arrayList.Add("5");
            arrayList.Add("6");
            arrayList.Add("7");
            arrayList.Add("8");
            arrayList.Add("9");
            arrayList.Add("10");

            arrayList.InsertAt("123", 5);
            Assert.Equal("123", arrayList[5]);
            Assert.True(arrayList.Capacity > 10);
        }

        [Fact]
        public void TestRemove()
        {
            MysCustomArrayList<string> arrayList = new MysCustomArrayList<string>();

            arrayList.Add("1");
            arrayList.Add("2");
            arrayList.Add("3");
            arrayList.Add("4");
            arrayList.Add("5");
            arrayList.Add("6"); // 5th
            arrayList.Add("123");
            arrayList.Add("8");
            arrayList.Add("9");
            arrayList.Add("10");

            arrayList.Remove(5); // 5th
            Assert.Equal("123", arrayList[5]);
        }

        [Fact]
        public void TestRemoveValue()
        {
            MysCustomArrayList<string> arrayList = new MysCustomArrayList<string>();

            arrayList.Add("1");
            arrayList.Add("2");
            arrayList.Add("3");
            arrayList.Add("4");
            arrayList.Add("5");
            arrayList.Add("6");
            arrayList.Add("123");
            arrayList.Add("8");
            arrayList.Add("9");
            arrayList.Add("10");

            arrayList.Remove("123");
            Assert.Equal("8", arrayList[6]);
        }
    }
}
