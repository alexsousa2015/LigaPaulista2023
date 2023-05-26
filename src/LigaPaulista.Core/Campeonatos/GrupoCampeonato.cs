using System.Data;

namespace LigaPaulista.Core.Campeonatos
{
    /// <summary>
    /// Grupo por Campeonato
    /// </summary>
    public class GrupoCampeonato
    {
        public int IdGrupo { get; set; }
        public int IdCampeonato { get; set; }

        /// <summary>
        /// Cadastra grupo em um Campeonato
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="campeonato"></param>
        /// <returns></returns>
        public int CadastrarGrupoCampeonato(int grupo, int campeonato)
        {
            return 0;
        }

        /// <summary>
        /// Retorna todos os grupos
        /// </summary>
        /// <returns></returns>
        public DataSet RetornaGrupos()
        {
            return null;
        }

        /// <summary>
        /// Retorna Grupos por ID de Grupo
        /// </summary>
        /// <param name="ig_grupo"></param>
        /// <returns></returns>
        public DataSet RetornaGrupos(int ig_grupo)
        {
            return null;
        }
    }
}
