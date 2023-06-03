#region

using System.Linq;
using Newtonsoft.Json;

#endregion

namespace TrendyolAPI.Models
{
    public class Counts
    {
        [JsonProperty("created")] public int Created { get; set; }

        [JsonProperty("preparing")] public int Preparing { get; set; }

        [JsonProperty("delivered")] public int Delivered { get; set; }

        [JsonProperty("unDelivered")] public int UnDelivered { get; set; }

        [JsonProperty("returned")] public int Returned { get; set; }

        [JsonProperty("createdInbound")] public int CreatedInbound { get; set; }

        [JsonProperty("shippedInbound")] public int ShippedInbound { get; set; }

        [JsonProperty("waitingInAction")] public int WaitingInAction { get; set; }

        [JsonProperty("accepted")] public int Accepted { get; set; }

        [JsonProperty("rejected")] public int Rejected { get; set; }

        [JsonProperty("cancel")] public int Cancel { get; set; }

        [JsonProperty("shipped")] public int Shipped { get; set; }

        [JsonProperty("creating")] public int Creating { get; set; }

        [JsonProperty("atCollectionPoint")] public int AtCollectionPoint { get; set; }

        [JsonProperty("preparingDefective")] public int PreparingDefective { get; set; }

        [JsonProperty("shippedDefective")] public int ShippedDefective { get; set; }

        [JsonProperty("atCollectionPointDefective")]
        public int AtCollectionPointDefective { get; set; }

        [JsonProperty("deliveredDefective")] public int DeliveredDefective { get; set; }

        [JsonProperty("undeliveredDefective")] public int UndeliveredDefective { get; set; }

        [JsonProperty("returnedDefective")] public int ReturnedDefective { get; set; }

        [JsonProperty("createdAssembly")] public int CreatedAssembly { get; set; }

        [JsonProperty("appointedAssembly")] public int AppointedAssembly { get; set; }

        [JsonProperty("completedAssembly")] public int CompletedAssembly { get; set; }

        [JsonProperty("uncompletedAssembly")] public int UncompletedAssembly { get; set; }

        [JsonProperty("shipment")] public int Shipment { get; set; }
    }
}