using System.Text.Json.Serialization;
using Microsoft.VisualBasic.FileIO;

namespace AMS_DBTC_API_v2.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Sex
    {
        M,
        F
    }
}
