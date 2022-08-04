using Database;
using Database.Classes;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public static class BuisnessLL
    {
        static public Task<List<Sample>> GetSamplesCollection()
        {
            return DBService.GetSamplesCollectionAsync();
        }

        static public Task<List<AvgSample>> GetAvgSamplesCollection()
        {
            return DBService.GetAvgSamplesCollectionAsync();
        }
        static public Task<List<HandleException>> GetHandleExceptionCollection()
        {
            return DBService.GetHandleExcCollectionAsync();
        }

        public static Task<ExceptionCounter> GetMostCommenException()
        {
            return DBService.GetMostCommenActivationReasonAsync();
        }

        static public Task<List<ActivationReason>> GetActReasCollection()
        {
            return DBService.GetActReasCollectionAsync();
        }
        static public Task<List<ActivationHistory>> GetActHistCollection()
        {
            return DBService.GetActHistCollectionAsync();
        }
        static public Task<List<ExceptionCounter>> GetExceptionsCountersCollection()
        {
            return DBService.GetExcCounCollectionAsync();
        }
    }
}
