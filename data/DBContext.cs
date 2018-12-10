using data.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace data
{
    public class DBContext
    {

        internal DBConnection _repo = new DBConnection("mongodb://mongo:27017", "UnitTest");

        private const string _collectionName = "UnitTestModel";

        public IMongoCollection<UnitTestModel> Collection;

        public DBContext()
        {
            Collection = _repo.Db.GetCollection<UnitTestModel>(_collectionName);
        }


        public async Task<string> Insert(UnitTestModel UnitTestModel)
        {
            try
            {
                await Collection.InsertOneAsync(UnitTestModel);
                return "Ok";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert error:"+ex);
                return "Error";
            }
        }

        public string GetALL()
        {
            var sort = Builders<UnitTestModel>.Sort.Descending("_id");
            try
            {
                var item = Collection.Find(new BsonDocument()).Sort(sort).Limit(1).FirstOrDefault();

                if (item.Status)
                    return "Ok";
                return "Failed";
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Insert error:"+ex);
                return "Error";
            }

        }

    }

}
