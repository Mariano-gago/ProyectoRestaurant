using Application.Models;
using Proyect_Restaurant.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyect_Restaurant.Sections.RecuperarCuenta
{
    public partial class RecuperarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Genera numero random desde 100000 a 999999
            Random random = new Random();
            int NumRandom = random.Next(100000, 999999);

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress(ConfigurationManager.AppSettings["From"], ConfigurationManager.AppSettings["Asunto"], System.Text.Encoding.UTF8);
            correo.To.Add(EmailText.Text);
            correo.Subject = "Codigo para recuperar la Clave";
            correo.Body = "Con el siguiente codigo " + NumRandom + "podras recuperar tu cuenta, NO LO COMPARTAS CON NADIE";
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = ConfigurationManager.AppSettings["Host"];
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["CredentialMail"], ConfigurationManager.AppSettings["CredentialPass"]);

            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors ssqlPolicyErrors) { return true; };

            smtp.EnableSsl = true;
            smtp.Send(correo);


            var empleado = new Empleados();
            var loginService = new LoginService();

            empleado.Codigo = NumRandom;
            empleado.Mail = EmailText.Text;

            loginService.Codigo(empleado);


        }


        protected void RecuperarCuenta_Click(object sender, EventArgs e)
        {
            var loginService = new LoginService();
            var empleado = new Empleados();

            empleado.Codigo = int.Parse(CodigoText.Text);
            empleado.Mail = EmailText.Text;

            bool codigoVerificado = bool.Parse(loginService.VerificarCodigo(empleado).ToString());

            if(codigoVerificado == true)
            {
                Session["Codigo"] = "true";
                Session["Mail"] = EmailText.Text;
                Response.Redirect("RecuperarCuentaFin.aspx");
            }
            else
            {
                Session["Codigo"] = "false";
            }
        }
    }
}