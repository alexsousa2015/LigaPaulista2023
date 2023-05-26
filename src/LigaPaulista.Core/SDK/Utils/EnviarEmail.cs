using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace LigaPaulista.Core.SDK.Utils
{
    /// <summary>
    /// Classe EnviarEmail
    /// </summary>
    public class EnviarEmail
    {
        #region Parâmetros de configuração em arquivo
        public const string PSmtp = "_smtp";
        public const string PSite = "_site";
        public const string PEmail = "_emailContato";
        public const string PSenha = "_senha";
        public const string PPorta = "_porta";
        public const string PSsl = "_ssl";
        #endregion

        public string EmailPara { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string Status { get; set; }
        public string ReplyTo { get; set; }
        public string OrigemCfg { get; set; }

        #region Propriedades de Configuração
        private static string Smtp { get; set; }
        private static string Senha { get; set; }
        private static string EmailDe { get; set; }
        private static string NomeDe { get; set; }
        private static string Site { get; set; }
        private static int Porta { get; set; }
        private static bool Ssl { get; set; }
        #endregion

        /// <summary>
        /// Cria um objeto EnviarEmail
        /// </summary>
        public EnviarEmail()
        {
            var app = ConfigurationManager.AppSettings;

            Smtp = !string.IsNullOrEmpty(app["_smtp"]) ? app["_smtp"] : "smtps.uol.com.br";
            Senha = !string.IsNullOrEmpty(app["_senha"]) ? app["_senha"] : "142536a";
            EmailDe = !string.IsNullOrEmpty(app["_emailContato"]) ? app["_emailContato"] : "formulaweb.digital@uol.com.br";
            NomeDe = (!string.IsNullOrEmpty(app["_site"]) ? app["_site"].Replace("[", "").Replace("]", "") : EmailDe);
            Site = !string.IsNullOrEmpty(app["_site"]) ? app["_site"] : "[n/d] ";
            Porta = !string.IsNullOrEmpty(app["_porta"]) ? Convert.ToInt32(app["_porta"]) : 0;
            Ssl = !string.IsNullOrEmpty(app["_ssl"]);
        }

        /// <summary>
        /// Enviar email conforme as variáveis preenchidas no objeto em THREAD
        /// </summary>
        /// <returns>bool</returns>
        public void Enviar()
        {
            try
            {
                //if (Validacao.ValidaEmail(emailDe) && Validacao.ValidaEmail(emailPara))
                //{
                var from = new MailAddress(EmailDe);
                var to = new MailAddress(EmailPara);

                var mailMsg = new MailMessage(from, to);

                if (!string.IsNullOrEmpty(ReplyTo))
                    mailMsg.ReplyToList.Add(new MailAddress(ReplyTo));

                mailMsg.Subject = (Site + Assunto);
                mailMsg.BodyEncoding = Encoding.GetEncoding("utf-8");//Encoding.GetEncoding("ISO-8859-1");

                var plainView = AlternateView.CreateAlternateViewFromString
                (Regex.Replace(Mensagem, @"<(.|\n)*?>", string.Empty), null, "text/plain");
                var htmlView = AlternateView.CreateAlternateViewFromString(Mensagem, null, "text/html");

                mailMsg.AlternateViews.Add(plainView);
                mailMsg.AlternateViews.Add(htmlView);

                var smtpUserInfo = new NetworkCredential(EmailDe, Senha);
                var objSmtp = new SmtpClient
                {
                    Host = Smtp,
                    UseDefaultCredentials = false,
                    Credentials = smtpUserInfo,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                if (Ssl)
                {
                    objSmtp.Port = Porta;
                    objSmtp.EnableSsl = Ssl;
                }
                else if (Porta != 0)
                {
                    objSmtp.Port = Porta;
                }

                var e = new Email { ObjSmtp = objSmtp, MailMsg = mailMsg };
                Thread thEmail = new Thread(MailThread);
                thEmail.Start(e);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Enviar email conforme as variáveis preenchidas no objeto AGORA
        /// </summary>
        /// <returns>bool</returns>
        public void EnviarEmailAgora()
        {
            try
            {
                var from = new MailAddress(EmailDe);
                var to = new MailAddress(EmailPara);

                var mailMsg = new MailMessage(from, to);

                if (!string.IsNullOrEmpty(ReplyTo))
                    mailMsg.ReplyToList.Add(new MailAddress(ReplyTo));

                mailMsg.Subject = (Site + Assunto);
                mailMsg.BodyEncoding = Encoding.GetEncoding("utf-8");//Encoding.GetEncoding("ISO-8859-1");

                var plainView = AlternateView.CreateAlternateViewFromString
                (Regex.Replace(Mensagem, @"<(.|\n)*?>", string.Empty), null, "text/plain");
                var htmlView = AlternateView.CreateAlternateViewFromString(Mensagem, null, "text/html");

                mailMsg.AlternateViews.Add(plainView);
                mailMsg.AlternateViews.Add(htmlView);

                var smtpUserInfo = new NetworkCredential(EmailDe, Senha);
                var objSmtp = new SmtpClient
                {
                    Host = Smtp,
                    UseDefaultCredentials = false,
                    Credentials = smtpUserInfo,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                if (Ssl)
                {
                    objSmtp.Port = Porta;
                    objSmtp.EnableSsl = Ssl;
                }
                else if (Porta != 0)
                {
                    objSmtp.Port = Porta;
                }

                objSmtp.Send(mailMsg);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private static void MailThread(object objEmail)
        {
            try
            {
                var e = (Email)objEmail;
                e.ObjSmtp.Send(e.MailMsg);
                e.MailMsg.Dispose();
            }
            catch
            {
            }
        }

        public class Email
        {
            public MailMessage MailMsg { get; set; }
            public SmtpClient ObjSmtp { get; set; }
        }


    }
}