using System;
using System.IO;
using System.Web.UI.WebControls;

namespace LigaPaulista.Site.Admin
{
    public partial class adm_fileManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void mostraArquivos()
        {
            // ricava il path
            string path = Request["path"];
            if (path == null)
                path = "/produtos/";

            // replace di caratteri pericolosi
            path = path.Replace("..", String.Empty).Replace("./", "/").Trim();
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath(path));

            // lista delle directory - costruisco il link
            foreach (DirectoryInfo localDir in dir.GetDirectories())
                ((Literal)FindControl("directories")).Text += "<li>" + String.Format("<a href=\"fileManager.aspx?path={1}{0}/\">{0}</a>", localDir.Name, path);

            //directories.Text += "<li><a href=\"fileManager.aspx?path=/fpt/downloads/>..</a>";
            // lista dei files
            foreach (FileInfo localFile in dir.GetFiles())
                ((Literal)FindControl("files")).Text += "<li>" + Request.ApplicationPath + "/" + localFile.Name;
        }

        protected void FileManager1_FileUploaded(object sender, IZ.WebFileManager.UploadFileEventArgs e)
        {
            Label1.Text += "http://www.wtta.com.br/" + e.UploadedFile.VirtualPath.Remove(0, 1) + "<br />";
        }
    }
}
