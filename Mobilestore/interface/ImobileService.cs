using Mobilestore.Models;
using MongoDB.Driver;

namespace Mobilestore.Interface{
    public interface ImobileService
    {
        IMongoCollection<MobileDeviceEntity> mobileDeviceCollection { get; }
        IEnumerable<MobileDeviceEntity> GetAllMobileDevices();

        MobileDeviceEntity GetMobileDevDetails(string Name);

        void Create(MobileDeviceEntity mobiledevice);

        void Update(string _id, MobileDeviceEntity mobiledevice);

        void Delete(string Name);
    }
}
