using DALProj;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLProj
{
    public static class BLL
    {
        static void Main(string[] args)
        {
        }
        static public List<BsonDocument> GetRawSamplesCollection() => DAL.GetRawSamplesList();
    }
}
