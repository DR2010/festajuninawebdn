using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanFestaJuninaCore
{
    public class DanAppSettings
    {
        public string DanAPIServiceDishes { get; set; }
        public string Organisation { get; set; }
        public string APIMongoDBLocation { get; set; }
        public string APIMongoDBDatabase{ get; set; } 
        public string MSAPIdishesPort  { get; set; }
        public string MSAPIordersPort { get; set; }
        public string MSAPIactivitiesPort { get; set; }
        public string SecurityMicroservice{ get; set; } 
        public string MSAPIdishesIPAddress{ get; set; } 
        public string MSAPIordersIPAddress{ get; set; }
        public string MSAPIactivitiesIPAddress { get; set; }
        public string KrakenAPI { get; set; }
        public string SecurityMicroserviceURL{ get; set; } 
        public string WEBDebug { get; set; }
        public string CollectionOrders { get; set; }
        public string CollectionSecurity { get; set; }
        public string CollectionDishes { get; set; }
        public string CollectionEvents { get; set; }
        public string CollectionActivities { get; set; }
        public string RedisAddressPort { get; set; }
        public string SYSID { get; set; }
    }
}
