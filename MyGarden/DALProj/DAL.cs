using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProj
{
    public static class DAL
    {
        static void Main(string[] args)
        {
        }
        private static string connectionString = "mongodb://localhost";
        public const string DATABASE_NAME = "MongoFinal"; 
        private static MongoClient client {get {return new MongoClient(connectionString);} }
        private static IMongoDatabase db
        {
            get
            {
                IMongoDatabase d = client.GetDatabase(DAL.DATABASE_NAME);
                return d;
            }
        }
        public static IMongoCollection<T> GetRawSamplesCollection<T>() where T : RawSample
        {
            return db.GetCollection<T>(typeof(T).FullName);
        }

        public static List<BsonDocument> GetRawSamplesList() 
        {
            var collection = db.GetCollection<BsonDocument>("samples");
            return (List<BsonDocument>)collection;
        }

        public static void InsertRawSample<T>(T RawSample) where T : RawSample
        {
            GetRawSamplesCollection<T>().InsertOne(RawSample);
        }
    }
}
