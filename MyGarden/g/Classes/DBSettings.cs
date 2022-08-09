using Database.Classes;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DBSettings
    {
        protected static MongoClient client { get { return new MongoClient("mongodb://localhost"); } }
        protected static IMongoDatabase db { get { return client.GetDatabase("MongoFinal"); }}

        protected static IMongoCollection<Sample> samplesCollection =
            db.GetCollection<Sample>("samples");

        protected static IMongoCollection<AvgSample> avgSamplesCollection =
            db.GetCollection<AvgSample>("avg_samples");

        protected static IMongoCollection<HandleException> handleExcCollection =
            db.GetCollection<HandleException>("handle_exception");

        protected static IMongoCollection<ActivationReason> actReasonCollection =
            db.GetCollection<ActivationReason>("activation_reason");

        protected static IMongoCollection<ActivationHistory> actHistoryCollection =
            db.GetCollection<ActivationHistory>("activation_history");

        protected static IMongoCollection<ExceptionCounter> excepCountersCollection =
            db.GetCollection<ExceptionCounter>("ex_counters");

        protected static IMongoCollection<User> usersCollection =
            db.GetCollection<User>("users");

        protected static IMongoCollection<Relays> relays =
    db.GetCollection<Relays>("currentActiveRelay");

    }
}
