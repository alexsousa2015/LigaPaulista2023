using System.Data;

namespace LigaPaulista.Core.Campeonatos
{
    class Localidade
    {
        public int ID_Localidade { get; set; }
        public string NomeLocalidade { get; set; }

        /// <summary>
        /// Cadastrar Localidade
        /// </summary>
        /// <param name="localidade"></param>
        /// <returns></returns>
        public int CadastraLocalidade(string localidade)
        {
            return 0;
        }

        /// <summary>
        /// Retorna todas as Localidades
        /// </summary>
        /// <returns></returns>
        public DataSet RetornaLocalidade()
        {
            return null;
        }

        /// <summary>
        /// Retorna Modalidade por id de Localidade
        /// </summary>
        /// <param name="id_localidade"></param>
        /// <returns></returns>
        public DataSet RetornaLocalidade(int id_localidade)
        {
            return null;
        }
    }
}