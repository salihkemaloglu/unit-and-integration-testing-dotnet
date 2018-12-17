using Data.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
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


        public void Insert(UnitTestModel UnitTestModel)
        {
            try
            {
                Collection.InsertOne(UnitTestModel);
                Console.WriteLine("Insert is  success:");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert error:" + ex);
            }
        }
 
        public void InsertStaticItems(List<UnitTestModel> model)
        {
            try
            {
                Collection.InsertMany(model);
                Console.WriteLine("Insert static item is success:");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert static items error: " + ex);
            }
        }
        public List<UnitTestModel> GetAll()
        {
            try
            {
                return Collection.Find(new BsonDocument()).ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Insert error:" + ex);
                return null;
            }

        }
        public UnitTestModel GetById(ObjectId id)
        {
            try
            {
                return Collection.Find(new BsonDocument("_id", id)).FirstAsync().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete error: " + ex);
                return null;
            }

        }
        public void Delete(ObjectId id)
        {
            try
            {
                Collection.DeleteOne(new BsonDocument("_id", id));
                Console.WriteLine("Delete item is success:");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete error: " + ex);
            }

        }
        public void Update(UnitTestModel model)
        {
            try
            {
                Collection.ReplaceOne(doc=>doc.Id==model.Id, model);
                Console.WriteLine("Update item is success:");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update error: " + ex);
            }

        }
    }

}
