using Data;
using Data.Model;
using System.Linq;
using Webapi.Todo;
using Xunit;

namespace UnitTest
{
    public class UnitTest
    {
        public UnitTest()
        {
            var item = new InsertStaticItems();
        }

        [Fact]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();
            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            // Assert
            Assert.True(result);
        }
        [Fact]
        public void GetAllItem_IsItemCountSix_ReturnsSix()
        {
            // Arrange
            CroudOperations operations = new CroudOperations();
            // Act
            var result = operations.GetAll();
            // Assert
            Assert.Equal(5, result.Count());

        }
        [Fact]
        public void GetFirstItem_ItemIsFirst_ReturnsAli()
        {
            // Arrange
            CroudOperations operations = new CroudOperations();
            // Act
            var result = operations.GetAll();
            // Assert
            Assert.Equal("Ali", result.FirstOrDefault().Name);

        }
        [Fact]
        public void DeleteOneItem_DeleteIsSuccess_ReturnsFive()
        {
            // Arrange
            CroudOperations operations = new CroudOperations();
            // Act
            var item = operations.GetAll();
            operations.Delete(item.FirstOrDefault().Id);
            // Assert
            Assert.Equal(5, operations.GetAll().Count());

        }
        [Fact]
        public void UpdateOneItem_UpdateIsSuccess_ReturnsUpdateMan()
        {
            // Arrange
            CroudOperations operations = new CroudOperations();
            // Act
            var item = operations.GetAll();
            operations.Update(new UnitTestModel {Id=item.LastOrDefault().Id, Name = "UpdateName", Surname = "UpdateSurname", Address = "UpdateAdress", FavoutireHero = "UpdateMan", Status = false });
            var result = operations.GetById(item.LastOrDefault().Id);
            // Assert
            Assert.Equal("Update", result.FavoutireHero);

        }

    }

}



