using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using Webapi.Todo;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        readonly CroudOperations operation = new CroudOperations();
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            return Json(operation.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(ObjectId id)
        {
            return Json(operation.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]UnitTestModel model)
        {
            operation.Insert(model);
        }

        // PUT api/values/
        [HttpPut]
        public void Put([FromBody]UnitTestModel model)
        {
            operation.Update(model);
        }


        // DELETE api/values
        [HttpDelete]
        public void Delete([FromBody]UnitTestModel model)
        {
            operation.Delete(model.Id);
        }
    }
}
