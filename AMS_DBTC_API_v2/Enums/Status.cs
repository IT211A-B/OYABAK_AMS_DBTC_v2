using System.Text.Json.Serialization;

namespace AMS_DBTC_API_v2.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        Present,
        Absent,
        Late
    }
}
