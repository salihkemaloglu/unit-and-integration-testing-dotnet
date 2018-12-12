using Data;
using System.Linq;
using Webapi.Todo;
using Xunit;

namespace UnitTest
{
    public class UnitTest
    {
        private readonly DBContext context = new DBContext();

        public UnitTest()
        {
            var item = new InsertStaticItems();
        }

        [Fact]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            var reservation = new Reservation();
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            Assert.True(result);
        }
        [Fact]
        public void GetAllItem_IsItemCountSix_ReturnsSix()
        {
            var result = context.GetAll().Count();
            Assert.Equal(5, result);

        }
        [Fact]
        public void GetFirstItem_ItemIsFirst_ReturnsAli()
        {
            var result = context.GetAll().FirstOrDefault();
            Assert.Equal("Ali", result.Name);

        }
        [Fact]
        public void DeleteOneItem_DeleteIsSuccess_ReturnsFive()
        {
            context.Delete(context.GetAll().FirstOrDefault().Id);
            Assert.Equal(5, context.GetAll().Count());

        }
        [Fact]
        public void UpdateOneItem_UpdateIsSuccess_ReturnsUpdateMan()
        {
            var item = context.GetAll().LastOrDefault();
            context.Update(item);
            var result = context.GetById(item.Id);
            Assert.Equal("Update", result.FavoutireHero);

        }

    }

}



