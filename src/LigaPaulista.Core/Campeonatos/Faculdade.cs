using System.Data;

namespace LigaPaulista.Core.Campeonatos
{
    class Faculdade
    {
        public int ID_faculdade { get; set; }
        public string NomeFaculdade { get; set; }

        /// <summary>
        /// Cadastra Faculdades
        /// </summary>
        /// <param name="faculdade"></param>
        /// <returns></returns>
        public int CadastrarFaculdade(string faculdade)
        {
            return 0;
        }

        /// <summary>
        /// Retorna todas as Faculdades
        /// </summary>
        /// <returns></returns>
        public DataSet RetornaFaculdade()
        {
            return null;
        }

        /// <summary>
        /// Retorna faculdade por id de Faculdade
        /// </summary>
        /// <param name="id_faculdade"></param>
        /// <returns></returns>
        public DataSet RetornaFaculdade(int id_faculdade)
        {
            return null;
        }
    }
}
