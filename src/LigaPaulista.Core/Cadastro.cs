using System;
using System.Data;
using System.Text;
using Formula;

namespace LigaPaulista.Core
{
    /// <summary>
    /// Summary description for Cadastro
    /// </summary>
    public class Cadastro
    {
        public int id_cadastro;
        public int idade;
        public string numero;
        public int origem;
        public string foto;
        public string nome;
        public string sobrenome;
        public string email;
        public string telefone;
        public string celular;
        public string sexo;
        public string estado_civil;
        public string endereco;
        public string complemento;
        public string bairro;
        public string cep;
        public string cidade;
        public string estado;
        public string pais;
        public string cpf;
        public string rg;
        public string senha;
        //public string titulo_eleitor;
        public int faculdade;
        public DateTime data_nasc;
        public DateTime data_cadastro;

        public string tipo_cadastro;

        /// <summary>
        /// Inseri novo Usuario
        /// </summary>
        /// <returns></returns>
        public bool inserir()
        {
            var sb = new StringBuilder();
            sb.Append("Insert into Cadastro");
            sb.Append("(nome, sobrenome, email, telefone, celular, nasc, idade, sexo, civil, endereco, numero,");
            sb.Append("complemento,bairro, cep, cidade, estado, pais, cpf, rg, titulo, faculdade, origem, data,senha) Values ");
            sb.AppendFormat("('{0}','{1}','{2}','{3}','{4}',Convert(datetime, '{5}', 103),{6},'{7}','{8}','{9}',{10},",
                nome, sobrenome, email, telefone, celular, data_nasc, idade, sexo, estado_civil, endereco, numero);
            sb.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{12}',{8},'{9}','{10}','{11}')",
                complemento, bairro, cep, cidade, estado, pais, cpf, rg, faculdade, origem, Converter.DataSql(data_cadastro), senha, tipo_cadastro);

            var sql = new Sql
            {
                strSql = sb.ToString()
            };
            return sql.query();
        }

        /// <summary>
        /// Altera Usuario
        /// </summary>
        /// <returns></returns>
        public bool alterar()
        {
            var sb = new StringBuilder();

            sb.Append("Update Cadastro ");
            sb.AppendFormat("set nome = '{0}',sobrenome = '{1}',email='{2}',telefone='{3}',celular='{4}',nasc=Convert(datetime, '{5}', 104),idade='{6}',sexo='{7}',civil='{8}',endereco='{9}',numero='{10}',",
                nome, sobrenome, email, telefone, celular, data_nasc, idade, sexo, estado_civil, endereco, numero);
            sb.AppendFormat("complemento='{0}',bairro='{1}',cep='{2}',cidade='{3}',estado='{4}',pais='{5}',cpf='{6}',rg='{7}',titulo='{12}',faculdade='{8}' Where ID_CADASTRO = {11}",
                complemento, bairro, cep, cidade, estado, pais, cpf, rg, faculdade, origem, data_cadastro, id_cadastro, tipo_cadastro);

            var sql = new Sql
            {
                strSql = sb.ToString()
            };

            return sql.query();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataSet preencheEntidades()
        {
            var sql = new Sql
            {
                strSql = ("SELECT id_entidade, entidade FROM entidades where entidade not like '[0-9]%' and isnull(ativo, 1) = 1 order by entidade")
            };
            return sql.queryDs();
        }

        /// <summary>
        /// 
        /// </summary> <param name="email"></param>
        /// <returns></returns>
        public static bool ExisteEmail(string email)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("SELECT EMAIL FROM CADASTRO WHERE EMAIL = '{0}'", email);

            var sql = new Sql
            {
                strSql = sb.ToString()
            };

            var ds = sql.queryDs();

            if (Utils.existeDataSet(ds))
                return true;

            return false;
        }

        /// <summary>
        /// Retorna Cadastrado por email
        /// </summary>
        /// <param name="email">Email do Cadastrado</param>
        /// <returns></returns>
        public static Cadastro RetornaPorEmail(string email)
        {
            var sb = new StringBuilder();
            sb.Append("SELECT ID_CADASTRO,NOME,SOBRENOME,EMAIL,TELEFONE,CELULAR,NASC,IDADE,SEXO,CIVIL,ENDERECO,NUMERO,COMPLEMENTO,BAIRRO");
            sb.AppendFormat(",CEP,CIDADE,ESTADO,PAIS,CPF,RG,TITULO,FACULDADE,ORIGEM,DATA,SENHA,FOTO FROM CADASTRO WHERE EMAIL = '{0}'", email);

            var sql = new Sql
            {
                strSql = sb.ToString()
            };

            var ds = sql.queryDs();

            if (Utils.existeDataSet(ds))
            {
                var rows = ds.Tables[0].Rows[0];

                var cadastro = new Cadastro
                {
                    id_cadastro = Converter.objToInt(rows["ID_CADASTRO"]),
                    idade = Converter.objToInt(rows["IDADE"]),
                    numero = Converter.objToStr(rows["NUMERO"]),
                    origem = Converter.objToInt(rows["ORIGEM"]),
                    nome = Converter.objToStr(rows["NOME"]),
                    sobrenome = Converter.objToStr(rows["SOBRENOME"]),
                    email = Converter.objToStr(rows["EMAIL"]),
                    telefone = Converter.objToStr(rows["TELEFONE"]),
                    celular = Converter.objToStr(rows["CELULAR"]),
                    sexo = Converter.objToStr(rows["SEXO"]),
                    estado_civil = Converter.objToStr(rows["CIVIL"]),
                    endereco = Converter.objToStr(rows["ENDERECO"]),
                    complemento = Converter.objToStr(rows["COMPLEMENTO"]),
                    bairro = Converter.objToStr(rows["BAIRRO"]),
                    cep = Converter.objToStr(rows["CEP"]),
                    cidade = Converter.objToStr(rows["CIDADE"]),
                    estado = Converter.objToStr(rows["ESTADO"]),
                    pais = Converter.objToStr(rows["PAIS"]),
                    cpf = Converter.objToStr(rows["CPF"]),
                    rg = Converter.objToStr(rows["RG"]),
                    senha = Converter.objToStr(rows["SENHA"]),
                    faculdade = Converter.objToInt(rows["FACULDADE"]),
                    data_nasc = Converter.objToDateTime(rows["NASC"]),
                    data_cadastro = Converter.objToDateTime(rows["DATA"]),
                    foto = Converter.objToStr(rows["FOTO"])
                };
                return cadastro;
            }
            return new Cadastro();
        }

        /// <summary>
        /// Envia senha
        /// </summary>
        /// <param name="c"></param>
        public static void enviarSenha(string email)
        {
            var mensagem = "<p>Conforme solicitado segue sua senha.</p><br>" +
                           "<strong>Acesse:</strong><br>" +
                           "Site: <a href='http://www.ligapaulista.com/login.aspx' target='_blank'>http://www.ligapaulista.com/</a><br>" +
                           "Login: " + RetornaPorEmail(email).email + "<br>" +
                           "Senha: " + RetornaPorEmail(email).senha +
                           "<p>Em caso de dúvidas ou dificuldades, entre em contato conosco " +
                           "através do site <a href='http://www.ligapaulista.com/' target='_blank'>http://www.ligapaulista.com/</a>.</p>";

            var mail = new EnviarEmail
            {
                emailPara = RetornaPorEmail(email).email,
                assunto = "Liga Paulista",
                mensagem = mensagem
            };
            mail.enviarEmail();
        }

        /// <summary>
        /// Retorna Cadastrado por email
        /// </summary>
        /// <param name="id">id do Cadastrado</param>
        /// <returns></returns>
        public Cadastro RetornaPorID(int id)
        {
            var sb = new StringBuilder();
            sb.Append("SELECT ID_CADASTRO, NOME,SOBRENOME,EMAIL,TELEFONE,CELULAR,NASC,IDADE,SEXO,CIVIL,ENDERECO,NUMERO,COMPLEMENTO,BAIRRO");
            sb.AppendFormat(",CEP,CIDADE,ESTADO,PAIS,CPF,RG,TITULO,FACULDADE,ORIGEM,DATA,SENHA,FOTO FROM CADASTRO WHERE ID_CADASTRO = '{0}'", id);

            var sql = new Sql
            {
                strSql = sb.ToString()
            };

            var ds = sql.queryDs();

            if (Utils.existeDataSet(ds))
            {
                var rows = ds.Tables[0].Rows[0];

                var cadastro = new Cadastro
                {
                    idade = Convert.ToInt32(rows["IDADE"]),
                    numero = Converter.objToStr(rows["NUMERO"]),
                    origem = Converter.objToInt(rows["ORIGEM"]),
                    nome = Converter.objToStr(rows["NOME"]),
                    sobrenome = Converter.objToStr(rows["SOBRENOME"]),
                    email = Converter.objToStr(rows["EMAIL"]),
                    telefone = Converter.objToStr(rows["TELEFONE"]),
                    celular = Converter.objToStr(rows["CELULAR"]),
                    sexo = Converter.objToStr(rows["SEXO"]),
                    estado_civil = Converter.objToStr(rows["CIVIL"]),
                    endereco = Converter.objToStr(rows["ENDERECO"]),
                    complemento = Converter.objToStr(rows["COMPLEMENTO"]),
                    bairro = Converter.objToStr(rows["BAIRRO"]),
                    cep = Converter.objToStr(rows["CEP"]),
                    cidade = Converter.objToStr(rows["CIDADE"]),
                    estado = Converter.objToStr(rows["ESTADO"]),
                    pais = Converter.objToStr(rows["PAIS"]),
                    cpf = Converter.objToStr(rows["CPF"]),
                    rg = Converter.objToStr(rows["RG"]),
                    senha = Converter.objToStr(rows["SENHA"]),
                    faculdade = Converter.objToInt(rows["FACULDADE"]),
                    data_nasc = Convert.ToDateTime(rows["NASC"]),
                    data_cadastro = Convert.ToDateTime(rows["DATA"]),
                    foto = Converter.objToStr(rows["FOTO"]),
                    tipo_cadastro = Convert.ToString(rows["TITULO"])
                };
                return cadastro;
            }
            return new Cadastro();
        }

        /// <summary>
        /// Verifica se é Cadastrado
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static bool VerificaCadastro(string[] arg)
        {
            var sql = new Sql
            {
                StringSql = ""
            };
            var ds = sql.queryDs();
            return false;
        }

        /// <summary>
        /// Insere Foto
        /// </summary>
        /// <returns></returns>
        public static bool InserirFoto(string imagem, int id)
        {
            var sql = new Sql
            {
                StringSql = string.Format("Update CADASTRO set FOTO = '{0}' Where ID_CADASTRO = {1}", imagem, id)
            };

            return sql.query();
        }
    }
}
