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

        public static bool IsRegistered(User user)
        {
            return DBService.IsRegistered(user);
        }

        static public Task<List<HandleException>> GetHandleExceptionCollection()
        {
            return DBService.GetHandleExcCollectionAsync();
        }

        public static Task<Sample> InsertNewSample(Sample newSample)
        {
            return DBService.InsertNewSample(newSample);
        }

        public static object ActivateRelay(Relays rl)
        {
            return DBService.ActivateRelay(rl);
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
        static public Task<Sample> GetLatestSample()
        {
            return DBService.GetLatestSampleAsync();
        }
        static public Task<AvgSample> GetLatestAvgSample()
        {
            return DBService.GetLatestAvgSampleAsync();
        }
        static public List<AvgSample> GetRaining()
        {
            return DBService.GetRainingAsync();
        }

        static public User UpdateUserPass(User userToUpdate, string newPassword)
        {
            return DBService.ChangeUserPassword(userToUpdate, newPassword);
        }

    }
}
