using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using CapaDatos;
using CapaNegocio;

namespace CapaNegocio
{
    public class OCKOValidaciones
    {
        public bool soloLetras(string TEXTBOX)
        {
            bool resultado = Regex.IsMatch(TEXTBOX, @"^[a-zA-Z]+$");
            if (!resultado)
            {
                //No es una letra del alfabeto, por lo tanto emitir mensaje de error.
            }
            return resultado;
        }

        public bool ValidarCamposVacios(string texto)
        {
            bool respuesta = true;
            if (texto=="")
            {
                respuesta = false;
            }
            return respuesta;
        }

        public void enviarEmail(String email, String asusnto, String mensaje)
        {
            MailMessage mail = new MailMessage("kordonezsystem@gmail.com", email);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("kordonezsystem@gmail.com", "1723520670Kevin");
            client.Host = "smtp.gmail.com";
            mail.Subject = asusnto;
            mail.Body = mensaje;
            client.Send(mail);
            /*MailMessage emailMessage = new MailMessage();
            emailMessage.From = new MailAddress("kordonezsystem@gmail.com");
            emailMessage.To.Add(email);
            emailMessage.Subject = asusnto;
            emailMessage.Body = mensaje;
            emailMessage.Priority = MailPriority.Normal;
            SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587);
            MailClient.EnableSsl = true;
            MailClient.Credentials = new System.Net.NetworkCredential("kordonezsystem@gmail.com", "1723520670Kevin");
            MailClient.UseDefaultCredentials = false;
            MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailClient.Send(emailMessage);*/

        }
        public string CrearPasswordTmp(int length)
        {
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        public bool ValidarCedula(String TxtNumeros)
        {
            int Numerico;
            var total = 0;
            int TamanoCedula = 10;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int provincia1 = 24;
            int Verificador = 6;

            if (int.TryParse(TxtNumeros, out Numerico) && TxtNumeros.Length == TamanoCedula)
            {
                int provincia = Convert.ToInt32(string.Concat(TxtNumeros[0], TxtNumeros[1], string.Empty));
                var digitosTres = Convert.ToInt32(TxtNumeros[2] + string.Empty);

                if ((provincia > 0 && provincia <= provincia1) && digitosTres < Verificador)
                {
                    var digitoVerificador = Convert.ToInt32(TxtNumeros[9] + string.Empty);
                    for (var k = 0; k < coeficientes.Length; k++)
                    {
                        var valor = Convert.ToInt32(coeficientes[k] + string.Empty) *
                                    Convert.ToInt32(TxtNumeros[k] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;


                    }
                    var digitoVerificadorObtenido = total >= 10 ? (total % 10) != 0 ?
                                                10 - (total % 10) : (total % 10) : total;
                    return digitoVerificadorObtenido == digitoVerificador;
                }
                return false;
            }
            return false;
        }
    }
}
