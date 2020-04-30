using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace copa_filmes_api.Models
{
    public class JsonFilme
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("titulo")]

        public string Titulo { get; set; }

        [JsonProperty("ano")]

        public int Ano { get; set; }

        [JsonProperty("nota")]

        public decimal Nota { get; set; }
    }
}
