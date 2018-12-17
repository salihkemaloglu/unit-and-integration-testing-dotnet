using Data.Model;
using Integration.Fixtures;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Integration
{
    public class IntegrationTest
    {
        private readonly TextContext _sut;

        public IntegrationTest()
        {
            _sut = new TextContext();
        }

        [Fact]
        public async Task CheckStatusCode_IsHttpOk_ReturnOk()
        {
            var result = HttpStatusCode.Accepted;
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/values"))
            {

                // Arrange
                var response = await _sut.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                // Act
                result = response.StatusCode;
            }

            // Assert
            Assert.Equal(HttpStatusCode.OK, result);
        }
        [Fact]
        public async Task GetItemsCount_IsCountFive_ReturnFive()
        {
            int itemsCount = 0;
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/values"))
            {
                var response = await _sut.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                itemsCount = JsonConvert.DeserializeObject<List<UnitTestModel>>(response.Content.ReadAsStringAsync().Result).Count;
            }
            // Assert
            Assert.Equal(5, itemsCount);
        }

        [Fact]
        public async Task InsertItem_IsInsertSuccess_ReturnDynamicCount()
        {

            var items = 0;
            int itemsCount = 0;
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/values"))
            {
                var response = await _sut.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                items = JsonConvert.DeserializeObject<List<UnitTestModel>>(response.Content.ReadAsStringAsync().Result).Count;
            }
            var item = new UnitTestModel
            {
                Name = "New",
                Surname = "Item",
                FavoutireHero = "New Man",
                Address = "New Şehir",
                Status = false
            };
            using (var request = new HttpRequestMessage(HttpMethod.Post, "/api/values"))
            {
                var json = JsonConvert.SerializeObject(item);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;
                    var response = await _sut.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                }
            }

            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/values"))
            {
                var response = await _sut.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                itemsCount = JsonConvert.DeserializeObject<List<UnitTestModel>>(response.Content.ReadAsStringAsync().Result).Count;
            }
            ++items;
            // Assert
            Assert.Equal(itemsCount, items);
        }

        [Fact]
        public async Task UpdateItem_IsUodateSuccess_ReturnUpdateMan()
        {

            string favouriteHeroName;
            List<UnitTestModel> item = new List<UnitTestModel>();
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/values"))
            {
                var response = await _sut.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                item = JsonConvert.DeserializeObject<List<UnitTestModel>>(response.Content.ReadAsStringAsync().Result);

            }
            var model = new UnitTestModel
            {
                Id = item.LastOrDefault().Id,
                Name = "Updateasdf",
                Surname = "UpUpasdf",
                FavoutireHero = "UpdateMan",
                Address = "Update City",
                Status = false
            };
            using (var request = new HttpRequestMessage(HttpMethod.Put, "/api/values"))
            {
                var json = JsonConvert.SerializeObject(model);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;
                    var response = await _sut.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                }
            }

            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/values"))
            {
                var response = await _sut.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                favouriteHeroName = JsonConvert.DeserializeObject<List<UnitTestModel>>(response.Content.ReadAsStringAsync().Result).ToList().LastOrDefault().FavoutireHero;
            }
            // Assert
            Assert.Equal("UpdateMan",favouriteHeroName);
        }
        [Fact]
        public async Task DeleteItem_IsDeleteSuccess_ReturnDynamicCount()
        {
            int itemsCount = 0;
            int deleteitemsCount = 0;
            List<UnitTestModel> item = new List<UnitTestModel>();
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/values"))
            {
                var response = await _sut.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                item = JsonConvert.DeserializeObject<List<UnitTestModel>>(response.Content.ReadAsStringAsync().Result).ToList();
                deleteitemsCount = item.Count;
            }
            var model = new UnitTestModel
            {
                Id=item.FirstOrDefault().Id
            };
            using (var request = new HttpRequestMessage(HttpMethod.Delete, "/api/values"))
            {
                var json = JsonConvert.SerializeObject(model);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;
                    var response = await _sut.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                }
            }

            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/values"))
            {
                var response = await _sut.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                itemsCount = JsonConvert.DeserializeObject<List<UnitTestModel>>(response.Content.ReadAsStringAsync().Result).Count;
            }
            --deleteitemsCount;
            // Assert
            Assert.Equal(itemsCount, deleteitemsCount);
        }

    }

}
