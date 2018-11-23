using System;
using System.Linq;
using webapi.Controllers;
using Xunit;

namespace unitTest
{
    public class UnitTest
    {
        [Fact]
        public void Test()
        {
            var controller=new ValuesController();
           
            var result=controller.Get();     
            Assert.Equal(2,result.Count());
        }
        [Fact]
        public void Test1()
        {
            var controller=new ValuesController();

            var result2=controller.Get(1);
            Assert.Equal("val",result2.ToString());
        }
    }
}
