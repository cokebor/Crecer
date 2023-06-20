using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using System.Data;

namespace ConsoleApplication1
{
    class Program
    {
        public enum Estados
        {
            Activo = 1,
            Inactivo = 0,
        }

        public enum Sexos
        {
            Masculino = 'M',
            Femenino = 'F'
        }

        static void Main(string[] args)
        {

            List<Estados> lista = Enum.GetValues(typeof(Estados)).Cast<Estados>().ToList();
            lista.Sort((p, q) => string.Compare(p.ToString(), q.ToString()));
            // Array.Sort(Enum.GetValues(typeof(Estados)), lista);


            foreach (var item in lista)
            {
                Console.Write(item);
                Console.WriteLine("\t" + item.GetHashCode());
            }

            lista = Enum.GetValues(typeof(Estados)).Cast<Estados>().ToList();
            lista = lista.OrderBy(p => p.ToString()).ToList();

            foreach (var item in lista)
            {
                Console.Write(item);
                Console.WriteLine("\t" + item.GetHashCode());
            }

            //lista = lista.OrderBy(p => p.Nombre).ToList();  //Retorna una lista ordenara por Nombre
            //lista = lista.OrderBy(p => p.Nombre).OrderBy(p => p.Apellido).ToList();  //Ordena la lista por Nombre y luego por apellido
            //lista = lista.OrderByDescending(p => p.Nombre).ToList();

            Console.ReadKey();
            Console.Clear();

            List<Sexos> lista2 = Enum.GetValues(typeof(Sexos)).Cast<Sexos>().ToList();
            lista2.Sort((p, q) => string.Compare(p.ToString(), q.ToString()));
            // Array.Sort(Enum.GetValues(typeof(Estados)), lista);


            foreach (var item in lista2)
            {
                Console.Write(item);
                Console.WriteLine("\t" + Convert.ToChar(item.GetHashCode()));
            }

            lista2 = Enum.GetValues(typeof(Sexos)).Cast<Sexos>().ToList();
            lista2 = lista2.OrderBy(p => p.ToString()).ToList();

            foreach (var item in lista2)
            {
                Console.Write(item);
                Console.WriteLine("\t" + Convert.ToChar(item.GetHashCode()));
            }


            Console.ReadKey();
            Console.Clear();

            //Console.WriteLine(Utilidades.Seguridad.CodificarPasword("cokebor", "030302"));

            Console.WriteLine(Utilidades.Seguridad.EncriptarClave("admin"));
            Console.WriteLine(Utilidades.Seguridad.DesencriptarClave(Utilidades.Seguridad.EncriptarClave("030302")));

            //Console.WriteLine(Utilidades.Seguridad.DecodificarPassword(Utilidades.Seguridad.CodificarPasword("cokebor", "030302")));


              Console.ReadLine();
            Console.Clear();

            Entidades.Usuario u = new Entidades.Usuario();
            u.NombreUsuario = "admin";
            u.Contraseña = "admin";

            Console.WriteLine(u.Contraseña);

            Console.WriteLine("Color:" + ColorTranslator.FromHtml("ActiveCaption").ToArgb().ToString());
            Console.Read();
            Console.Clear();
            Console.WriteLine("Enviar mail");

            EnviarEmail();


        }

        private static bool EnviarEmail()
        {

            MailMessage msg = new MailMessage();

            msg.To.Add("cokebor@gmail.com"); //destino

            //msg.From = new MailAddress("Email que quieras que aparezca de quien envia", "Nombre de quien envia", System.Text.Encoding.UTF8);
            msg.From = new MailAddress("jbordarampe@gmail.com", "Bordarampe Jorge", System.Text.Encoding.UTF8);

            msg.Subject = "Aqui va el asunto";

            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Body = "Y aqui el contenido";

            msg.BodyEncoding = System.Text.Encoding.UTF8;

            msg.IsBodyHtml = false; //Si vas a enviar un correo con contenido html entonces cambia el valor a true
                                    //Aquí es donde se hace lo especial

            msg.Attachments.Add(new Attachment(@"C:\Users\Usuario\Desktop\slider-kwm4Ng.PDF"));

            SmtpClient client = new SmtpClient();

            client.Credentials = new System.Net.NetworkCredential("jbordarampe@gmail.com", "030302Coke");

            client.Port = 587;

            client.Host = "smtp.gmail.com";//Este es el smtp valido para Gmail

            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail

            try

            {
                client.Send(msg);

                return true;
            }

            catch (Exception)

            {
                return false;
            }




        }


    }
}
