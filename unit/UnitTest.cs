using data;
using System.Threading.Tasks;
using webapi.Todo;
using Xunit;

namespace unitTest
{
    public class UnitTest
    {
        DBContext context = new DBContext();
        [Fact]
        public async Task CanBeCancelledBy_UserIsAdmin_ReturnsTrueAsync()
        {
            var reservation = new Reservation();
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            await context.Insert(new data.Model.UnitTestModel { Status = result });
            Assert.True(result);

        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 2)]
        [InlineData(2, 3, 6)]
        public void MultiplyNumbers_ResultIsCorrect_ReturnsMultiplyNumbers(float number1, float number2, float multiplication)
        {
            var multi=new Multiply();
            float testMultiplication = multi.MultiplyNumbers(number1,number2);
            Assert.Equal(multiplication, testMultiplication);
        }
    }


}
