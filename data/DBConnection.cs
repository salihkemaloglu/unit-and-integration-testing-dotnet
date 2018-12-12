using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    class DBConnection
    {
        public MongoClient Client;

        public IMongoDatabase Db;

        public DBConnection(string url, string database)
        {
            Client = new MongoClient(url);

            Db = this.Client.GetDatabase(database);
        }
    }
}
