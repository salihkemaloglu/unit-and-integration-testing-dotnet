
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Data.Model;
using MongoDB.Bson;

namespace Webapi.Todo
{
    public class CroudOperations
    {
  
        private readonly DBContext context=new DBContext();
        public List<UnitTestModel> GetAll(){

            return context.GetAll();
        }
       
        public void Insert(UnitTestModel model)
        {
            context.Insert(model);
        }
        public UnitTestModel GetById(ObjectId id){
           return context.GetById(id);
        }

        public void Delete(ObjectId id)
        {
            context.Delete(id);
        }

        public void Update(UnitTestModel model)
        {
            context.Update(model);
        }
    }

}
