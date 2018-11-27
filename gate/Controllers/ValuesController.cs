using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace gate.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
   
        // GET api/values
        [HttpGet]
        public bool Get()
        {
            if (GetTestResultData())
                return true;
            else
                return false;
           
        }
        public bool GetTestResultData()
        {
            //Get Directory info
            //for local directory
            var baseDirectory = new DirectoryInfo(@"C:\Users\LA\Desktop\Testarea\C#\src\unit\TestResults");
            var testFile = baseDirectory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
            //Read trx file and load xml
            StreamReader reader = new StreamReader(testFile.FullName);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(reader.ReadToEnd());
            //parse xml to json ang get test result from json object
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            var jsonTestFile = JObject.Parse(jsonText);
            var result = jsonTestFile["TestRun"]["ResultSummary"].First.First.ToString();    
            reader.Close();

            if (result == "Completed")
                return true;
            else
                return false;
        }      
    }
}
