using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using copa_filmes_api.Code;
using copa_filmes_api.Dominio;
using copa_filmes_api.Entidades;
using copa_filmes_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace copa_filmes_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        [HttpPost]
        public IActionResult GerarCampeonato([FromBody]JsonListaFilmes filmes)
        {
            try
            {
                if (filmes.Filmes.Count() < 8)
                    throw new Exception("Número de filmes baixo no exigido pra gerar o campeonato");

                List<Filme> participantes = new List<Filme>();

                foreach (JsonFilme item in filmes.Filmes)
                {
                    participantes.Add(Mapeador.DePara<JsonFilme, Filme>(item));
                }

                Campeao campeao = CampeonatoDOM.GerarCampeonato(participantes);

                return Ok(JsonConvert.SerializeObject(new { campeao }, new JsonSerializerSettings{
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex));
            }
        }
    }
}