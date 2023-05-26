using System;
using System.Data;

namespace LigaPaulista.Core.Campeonatos
{
    public class GrupoFaculdade
    {
        public int IdGrupo { get; set; }
        public int IdFaculdade { get; set; }

        /// <summary>
        /// Cadastra Grupo por Faculdade
        /// </summary>
        /// <param name="id_grupo"></param>
        /// <param name="id_faculdade"></param>
        /// <returns></returns>
        public bool CadastraGrupoFaculdade(int id_grupo, int id_faculdade)
        {
            return false;
        }

        /// <summary>
        /// Retorna Todos os grupos
        /// </summary>
        /// <returns></returns>
        public int RetornaGrupoFaculdade()
        {
            return 0;
        }

        /// <summary>
        /// Retorna grupo por id de grupo
        /// </summary>
        /// <param name="id_grupo"></param>
        /// <returns></returns>
        public DataSet RetornaGrupoFaculdade(int id_grupo)
        {
            return null;
        }

        /// <summary>
        /// Altera Grupo em que a faculdade está
        /// </summary>
        /// <returns></returns>
        public int AvancarGrupoFaculdade()
        {
            return 0;
        }
    }
}

