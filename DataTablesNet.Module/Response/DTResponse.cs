using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataTablesNet.Module.Response {
   public class DTResponse<T> {
      [JsonProperty("draw")]
      public int Draw { get; set; }
      [JsonProperty("recordsTotal")]
      public int RecordsTotal { get; set; }
      [JsonProperty("recordsFiltered")]
      public int RecordsFiltered { get; set; }
      [JsonProperty("data")]
      public IEnumerable<T> Data { get; set; }
      [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
      public string Error { get; set; }
   }
}
