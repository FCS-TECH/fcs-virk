using FCS.Virk.VrModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FCS.Virk
{
    public class VrResponseParser
    {
        public List<VrVirksomhed?> ParseVrResponse(string jsonData)
        {
            var result = new List<VrVirksomhed?>();
            
            var cvrObject = JObject.Parse(jsonData);
            
            var numHits = (int) cvrObject.SelectToken("hits")?.SelectToken("total")!;
            
            if (numHits == 0)
                return result;
            
            var cvrHits = cvrObject.SelectToken("hits")?.SelectToken("hits");
            
            for (var i = 0; i < numHits; i++)
            {
                var cObject = cvrHits?[i]?["_source"] != null ? (JObject?)cvrHits[i]?["_source"]?["Vrvirksomhed"] : null;
                
                var jsonString = JsonConvert.SerializeObject(cObject);
                
                var o = JsonConvert.DeserializeObject<VrVirksomhed>(jsonString);

                result.Add(o);
            }

            return result;
        }
    }
}