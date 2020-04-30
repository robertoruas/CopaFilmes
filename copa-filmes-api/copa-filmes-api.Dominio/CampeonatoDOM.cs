using copa_filmes_api.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace copa_filmes_api.Dominio
{
    public static class CampeonatoDOM
    {
        public static Campeao GerarCampeonato(List<Filme> filmes)
        {
            try
            {
                List<Confronto> quartasDeFinal = GerarQuartasDeFinal(filmes);

                List<Confronto> semiFinal = GerarSemiFinal(quartasDeFinal);

                Confronto final = GerarFinal(semiFinal);

                Campeao campeao = RealizaFinal(final);

                return campeao;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static Campeao RealizaFinal(Confronto final)
        {
            try
            {
                if (final.Filme1.Nota >= final.Filme2.Nota)
                {
                    return new Campeao
                    {
                        Primeiro = final.Filme1,
                        Segundo = final.Filme2
                    };
                }

                return new Campeao
                {
                    Primeiro = final.Filme2,
                    Segundo = final.Filme1
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Filme RealizaConfronto(Confronto confronto)
        {
            try
            {
                if (confronto.Filme1.Nota >= confronto.Filme2.Nota)
                {
                    return confronto.Filme1;
                }

                return confronto.Filme2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<Confronto> GerarQuartasDeFinal(List<Filme> filmes)
        {
            try
            {
                List<Confronto> quartasDeFinal = new List<Confronto>();

                filmes = filmes.OrderBy(f => f.Titulo).ToList();

                while (filmes.Count() > 0)
                {
                    Confronto confronto = new Confronto();

                    confronto.Filme1 = filmes.FirstOrDefault();

                    confronto.Filme2 = filmes.LastOrDefault();

                    quartasDeFinal.Add(confronto);

                    filmes.RemoveAll(x => x.Id == confronto.Filme1.Id);
                    filmes.RemoveAll(x => x.Id == confronto.Filme2.Id);
                }

                return quartasDeFinal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<Confronto> GerarSemiFinal(List<Confronto> quartasDeFinal)
        {
            try
            {
                List<Confronto> semiFinal = new List<Confronto>();
                List<Filme> vencedores = new List<Filme>();

                foreach (Confronto confronto in quartasDeFinal)
                {
                    vencedores.Add(RealizaConfronto(confronto));
                }

                for (int i = 0; i < 3; i+=2)
                {
                    Confronto confronto = new Confronto
                    {
                        Filme1 = vencedores[i],
                        Filme2 = vencedores[i + 1]
                    };
                    semiFinal.Add(confronto);
                }
                return semiFinal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Confronto GerarFinal(List<Confronto> semiFinal)
        {
            try
            {
                return new Confronto
                {
                    Filme1 = RealizaConfronto(semiFinal[0]),
                    Filme2 = RealizaConfronto(semiFinal[1])
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
