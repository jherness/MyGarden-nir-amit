using Database.Classes;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Bindings;
using MongoDB.Driver.Core.Operations;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Database
{
    public class DBService : DBSettings
    {
        public static async Task<List<ExceptionCounter>> GetExcCounCollectionAsync()
        {
            try
            {
                return await excepCountersCollection.Find(new BsonDocument()).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<List<ActivationHistory>> GetActHistCollectionAsync()
        {
            try
            {
                return await actHistoryCollection.Find(new BsonDocument()).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<Sample> InsertNewSample(Sample newSample)
        {
            try 
            {
                await samplesCollection.InsertOneAsync(newSample);
                return await GetLatestSampleAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<List<ActivationReason>> GetActReasCollectionAsync()
        {
            try
            {
                return await actReasonCollection.Find(new BsonDocument()).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<List<Sample>> GetSamplesCollectionAsync()
        {
            try{
                return await samplesCollection.Find(new BsonDocument()).ToListAsync();
            }
            catch (Exception ex) {
                return null;
            }
        }

        public static async Task<List<AvgSample>> GetAvgSamplesCollectionAsync()
        {
            try
            {
                return await avgSamplesCollection.Find(new BsonDocument()).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<List<HandleException>> GetHandleExcCollectionAsync()
        {
            try
            {
                return await handleExcCollection.Find(new BsonDocument()).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<ExceptionCounter> GetMostCommenActivationReasonAsync()
        {
            try
            {
                var item = await GetExcCounCollectionAsync();
                item.Sort((a, b) => a.value.CompareTo(b.value));
                return item.ElementAt(item.Count - 1);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<Sample> GetLatestSampleAsync()
        {
            try
            {
                var item = await GetSamplesCollectionAsync();
                item.Sort((a, b) => a.datetime_of_sample.CompareTo(b.datetime_of_sample));
                return item.ElementAt(item.Count - 1);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<AvgSample> GetLatestAvgSampleAsync()
        {
            try
            {
                var item = await GetAvgSamplesCollectionAsync();
                item.Sort((a, b) => a.datetime_of_sample.CompareTo(b.datetime_of_sample));
                return item.ElementAt(item.Count - 1);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<AvgSample> GetRainingAsync()
        {
            try
            {
                var aggregate = avgSamplesCollection.Aggregate().Match(x => x.is_raining);
                return aggregate.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool IsRegistered(User user)
        {
            try
            {
                return usersCollection.Find(x => (x.eMail == user.eMail) && (x.password == user.password)).ToList().Count != 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static User ChangeUserPassword(User userToChange, string newPassword)
        {
            var filter = Builders<User>.Filter.Where(u => u.eMail == userToChange.eMail &&
                u.password == userToChange.password);
            var update = Builders<User>.Update.Set(u => u.password, newPassword);
            var options = new FindOneAndUpdateOptions<User>();
            return usersCollection.FindOneAndUpdate(filter, update, options);
        }

    }
}