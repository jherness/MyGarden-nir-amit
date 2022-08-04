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
    }
}