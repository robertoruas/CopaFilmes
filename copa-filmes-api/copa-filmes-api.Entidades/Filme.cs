using System;

namespace copa_filmes_api.Entidades
{
    public class Filme
    {
        public string Id { get; set; }

        public string Titulo { get; set; }

        public int Ano { get; set; }

        public decimal Nota { get; set; }
    }
}
