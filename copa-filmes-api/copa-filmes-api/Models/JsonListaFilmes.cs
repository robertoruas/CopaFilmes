using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace copa_filmes_api.Models
{
    public class JsonListaFilmes
    {
        [JsonProperty("filmes")]
        public List<JsonFilme> Filmes { get; set; }
    }
}
