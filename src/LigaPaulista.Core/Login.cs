using System;
using System.Web;
using Formula;

namespace LigaPaulista.Core
{
    public class Login
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Cadastro cadastro { get; set; }

        /// <summary>
        /// Verifica dados do usuario e caso o mesmo esteja na base de dados abre sessão para usuario
        /// </summary>
        /// <returns></returns>
        public bool Logar()
        {
            var sql = new Sql
                          {
                              strSql = string.Format("SELECT ID_CADASTRO,Nome,EMAIL  FROM CADASTRO WHERE EMAIL = '{0}' and SENHA = '{1}'", Email, Senha)
                          };

            var ds = sql.queryDs();

            if (Utils.existeDataSet(ds))
            {
                ID = Converter.objToInt(ds.Tables[0].Rows[0].ItemArray[0]);
                Nome = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[1]);
                Email = Converter.objToStr(ds.Tables[0].Rows[0].ItemArray[2]);
                cadastro = Cadastro.RetornaPorEmail(Email);
                HttpContext.Current.Session["Id"] = ID;
                HttpContext.Current.Session["Nome"] = Nome;
                HttpContext.Current.Session["Login"] = this;
                Acesso();
                ds.Dispose();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Insere acesso para usuario
        /// </summary>
        public void Acesso()
        {
            var sql = new Sql()
                          {
                              strSql = string.Format("INSERT INTO ACESSOS values ('{0}','{1}',getDate())", Email, HttpContext.Current.Request.UserHostAddress)
                          };
            sql.query();
        }

        /// <summary>
        /// Recupera senha do usuario
        /// </summary>
        /// <returns></returns>
        public bool RecuperaSenha()
        {
            var sql = new Sql
            {
                strSql =
                    ("select nome,senha email from cadastro where email = '" + Email.ToLower() + "'")
            };
            var ds = sql.queryDs();

            // vejo se existe o usuário
            if (Utils.existeDataSet(ds))
            {
                if (Convert.ToString(ds.Tables[0].Rows[0].ItemArray[3]).ToLower().Trim() == Email.ToLower().Trim())
                {
                    // preencho as variáveis
                    Nome = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[0]);
                    Senha = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[1]);

                    ds.Dispose();
                    return true;
                }
            }
            else
                return false;
            return false;
        }

        /// <summary>
        /// encerra a sessão do login, e redireciona para a página principal
        /// </summary>
        public static void encerrarSessao()
        {
            HttpContext.Current.Session["Login"] = "";
            HttpContext.Current.Session["Entidade"] = "";
            HttpContext.Current.Session["Representante"] = "";
            HttpContext.Current.Session["Atletas"] = "";
            HttpContext.Current.Session["IDPEDIDO"] = "";
            HttpContext.Current.Session["IDENTIDADE"] = "";

            HttpContext.Current.Session.Clear();
            HttpContext.Current.Response.Redirect("~/default.aspx");
        }

        /// <summary>
        /// Troca senha do usuario
        /// </summary>
        /// <returns></returns>
        public bool TrocaSenha()
        {
            var sql = new Sql
            {
                strSql = ("update CADASTRO set senha = '" + Senha + "' where id_cadastro = '" + ID + "'")
            };

            return sql.query();
        }

        /// <summary>
        /// verifica na página se tem um Usuário logado para poder entrar
        /// </summary>
        /// <returns></returns>
        public static void validarLogin()
        {
            // vejo se existe um usuário logado para a adm
            if (!Utils.existeSession("Login"))
            {
                var pagina = HttpContext.Current.Request.ServerVariables["URL"];
                if (!string.IsNullOrEmpty(pagina))
                    HttpContext.Current.Session["_redirect"] = "/" + pagina.Replace("mc/", "").Replace("he/", "");
                HttpContext.Current.Response.Redirect("verifica-cpf.aspx?login=bad");
            }
        }

        /// <summary>
        /// conta qtos acessos fez no site
        /// </summary>
        /// <returns></returns>
        public static string acessosSite()
        {
            var sql = new Sql
            {
                strSql = "select count(email) from acessos"
            };
            var ds = sql.queryDs();

            var total = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            ds.Dispose();

            return total;
        }

        /// <summary>
        /// conta qtos acessos fez no site
        /// </summary>
        /// <returns></returns>
        public static string acessosSitePorID(string email)
        {
            var sql = new Sql
            {
                strSql = string.Format("select count(email) from acessos where email = '{0}'", email)
            };
            var ds = sql.queryDs();

            var total = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            ds.Dispose();

            return total;
        }
    }
}
