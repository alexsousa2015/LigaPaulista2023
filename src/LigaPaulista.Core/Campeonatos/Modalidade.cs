using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Formula;
using Formula.Data;
using Microsoft.SqlServer.Server;

namespace LigaPaulista.Core.Campeonatos
{
    public class Modalidade
    {
        #region "Propriedades"

        public int IdModalidade { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Documento { get; set; }
        public string Obs { get; set; }
        public int Ativo { get; set; }

        #endregion

        #region "Construtor"

        public Modalidade() { }

        public Modalidade(int id, string nome)
        {
            this.IdModalidade = id;
            this.Nome = nome;
        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Cadastrar Modalidade
        /// </summary>
        /// <returns></returns>
        public void CadastraModalidade()
        {
            var sb = new StringBuilder();
            sb.Append("Insert into Modalidades (Modalidade, Imagem, Ativo)");
            sb.AppendFormat(" values ('{0}','{1}', {2})", Nome, Imagem, Ativo);

            var sql = new Sql
            {
                strSql = sb.ToString()
            };
            sql.query();
        }

        /// <summary>
        /// Altera Modalidade
        /// </summary>
        public void AlteraModalidade()
        {
            var sb = new StringBuilder();
            sb.Append("Update Modalidades ");
            sb.AppendFormat("set Modalidade = '{0}',Imagem = '{1}', Ativo = {2} where id_Modalidade = {3}", Nome, Imagem, Ativo, IdModalidade);

            var sql = new Sql
            {
                strSql = sb.ToString()
            };
            sql.query();
        }

        /// <summary>
        /// Retorna todas as modalidades
        /// </summary>
        /// <returns></returns>
        public static DataSet RetornaModalidade()
        {
            var sql = new Sql
            {
                strSql = "Select id_modalidade,modalidade,imagem from Modalidades where id_modalidade in (select distinct ID_MODALIDADE from dbo.CAMPEONATOS) and ativo = 1"
            };

            return sql.queryDs();
        }

        /// <summary>
        /// Retorna Modalidade por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataSet RetornaModalidade(int id)
        {
            var sql = new Sql
            {
                strSql = "Select id_modalidade,modalidade from Modalidades where id_modalidade = " + id
            };

            return sql.queryDs();
        }
        public DataSet RetornaModalidades(int id)
        {
            var sql = new Sql
            {
                strSql = "Select id_modalidade,modalidade,imagem from Modalidades where id_modalidade = " + id
            };

            return sql.queryDs();
        }

        /// <summary>
        /// Retorna Modalidade por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Modalidade GetModalidadeById(int id)
        {
            Modalidade objModalidade = null;

            var sql = new Sql
            {
                strSql = "Select id_modalidade,modalidade, observacoes, imagem, ativo from Modalidades where id_modalidade = " + id
            };

            var ds = sql.queryDs();
            if (Utils.existeDataSet(ds))
            {
                var drModalidade = ds.Tables[0].Rows[0];

                objModalidade = new Modalidade()
                {
                    IdModalidade = Convert.ToInt32(drModalidade["id_modalidade"]),
                    Nome = Convert.ToString(drModalidade["modalidade"]),
                    Obs = Convert.ToString(drModalidade["observacoes"]),
                    Imagem = drModalidade["imagem"].ToString(),
                    Ativo = Convert.ToInt32(drModalidade["ativo"]),
                };
            }
            return objModalidade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="arquivo"></param>
        /// <param name="nomearquivo"></param>
        public static void CadastrarDocumentoModalidade(int id, string arquivo, string nomearquivo, string ano)
        {
            var sql = new Sql
            {
                strSql = string.Format("INSERT INTO DOCUMENTOS_MODALIDADES values({0},'{1}','{2}','{3}')", id, arquivo, nomearquivo, ano)
            };
            sql.query();
        }

        public static List<string> RetornaAnosDocumentosModalidade()
        {
            var sb = new StringBuilder();
            sb.Append("Select distinct ANO from DOCUMENTOS_MODALIDADES");

            var sql = new Sql
            {
                StringSql = sb.ToString()
            };

            var ds = sql.queryDs();
            var anoDoctoModalidade = (from DataRow row in ds.Tables[0].Rows select row["ANO"].ToString()).ToList();

            //var anoAtual = DateTime.Now.Year.ToString();

            //if (anoDoctoModalidade.All(x => x != anoAtual)) anoDoctoModalidade.Add(anoAtual);

            return anoDoctoModalidade.OrderByDescending(Convert.ToInt32).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Modalidade> retornaDocumento(int id, string ano)
        {
            List<Modalidade> Arquivos;

            var sb = new StringBuilder();
            sb.Append("Select ID_MODALIDADE,DOCUMENTO,NOME from DOCUMENTOS_MODALIDADES ");
            sb.AppendFormat("where ID_MODALIDADE = {0} and ano = '{1}'", id, ano);


            var sql = new Sql
            {
                StringSql = sb.ToString()
            };

            var ds = sql.queryDs();

            if (Utils.existeDataSet(ds))
            {
                var oRow = ds.Tables[0].Rows;
                Arquivos = new List<Modalidade>();
                foreach (DataRow arquivo in oRow)
                {
                    var s = new Modalidade()
                    {
                        IdModalidade = (int)arquivo["ID_MODALIDADE"],
                        Nome = (string)arquivo["NOME"],
                        Documento = (string)arquivo["DOCUMENTO"]
                    };

                    Arquivos.Add(s);
                }
                return Arquivos;
            }
            return null;
        }

        public static DataSet retornaIDModalidade(string ano)
        {
            var sb = new StringBuilder();
            sb.Append("Select distinct dm.id_modalidade,m.MODALIDADE, m.imagem from DOCUMENTOS_MODALIDADES dm ");
            sb.Append("join MODALIDADES as m ");
            sb.Append("on m.ID_MODALIDADE = dm.ID_MODALIDADE ");
            sb.Append("where dm.ANO = '" + ano + "'");

            var sql = new Sql
            {
                StringSql = sb.ToString()
            };

            return sql.queryDs();
        }

        #endregion
    }
}