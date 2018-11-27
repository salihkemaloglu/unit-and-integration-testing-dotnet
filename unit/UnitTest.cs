using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using webapi.Controllers;
using Xunit;

namespace unitTest
{
    public class UnitTest
    {
        [Fact]
        public void Test()
        {
            var controller = new ValuesController();
            var result = controller.Get();
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public void Test1()
        {
            var controller = new ValuesController();

            var result2 = controller.Get(1);
            Assert.Equal("value", result2.ToString());
        }

        [Fact]
        public void Test2()
        {
            var controller = new ValuesController();

            var result2 = controller.Get(1);
            Assert.Equal("value", result2.ToString());
        }
        [Fact]
        public void Test3()
        {
            var controller = new ValuesController();

            var result2 = controller.Get(1);
            Assert.Equal("value", result2.ToString());
        }
        [Fact]
        public void Test4()
        {
            var controller = new ValuesController();

            var result2 = controller.Get(1);
            Assert.Equal("value", result2.ToString());
        }
        [Fact]
        public void Test5()
        {
            var controller = new ValuesController();

            var result2 = controller.Get(1);
            Assert.Equal("value", result2.ToString());
        }

    }
}
