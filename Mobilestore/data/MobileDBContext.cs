using Microsoft.Extensions.Options;
using Mobilestore.Interface;
using Mobilestore.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver; 

namespace Mobilestore.data
{
    public class MobileDBContext : ImobileService
    {
        
        public readonly IMongoDatabase _db;

        public MobileDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<MobileDeviceEntity> mobileDeviceCollection => 
        _db.GetCollection<MobileDeviceEntity>("mobiledevice");
        
        public IEnumerable<MobileDeviceEntity> GetAllMobileDevices()
        {
            return mobileDeviceCollection.Find(a => true).ToList();
        }

        public MobileDeviceEntity GetMobileDevDetails(string Name)
        {
            var mobileDeviceDetails = mobileDeviceCollection.Find(m =>m.Name == Name).FirstOrDefault();
            return mobileDeviceDetails;
        }

        public void Create(MobileDeviceEntity mobiledevice)
        {
            mobileDeviceCollection.InsertOne(mobiledevice);
        }
        public void Update(string _id, MobileDeviceEntity mobiledevice)
        {
            string sid = mobiledevice._id.ToString();
            
            var filter = Builders<MobileDeviceEntity>.Filter.Eq(x =>x._id,_id);
            var update = Builders<MobileDeviceEntity>.Update
                .Set("Name", mobiledevice.Name)
                .Set("company", mobiledevice.company)
                .Set("color", mobiledevice.color);

            mobileDeviceCollection.UpdateOne(filter,update);
        }
        public void Delete(string Name)
        {
            var filter = Builders<MobileDeviceEntity>.Filter.Eq(c => c.Name, Name);
            mobileDeviceCollection.DeleteOne(filter);
        }
        
  
    }

}
