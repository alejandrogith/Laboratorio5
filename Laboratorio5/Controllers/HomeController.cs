using Laboratorio5.Models;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio5.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Email()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Email(Email pemail) {

            string EmailOrigen = "develop2022HjABt@hotmail.com";
            string EmailDestino = pemail.EmailDestino;
            string password = "sTrATEnTiBUl";


            var senderEmail = new MailAddress(EmailOrigen, "Aledev");
            var receiverEmail = new MailAddress(EmailDestino, "RECEPTOR");
            var sub = pemail.Asunto;
            var body = pemail.Contenido;
            var smtp = new SmtpClient()
            {
                Host = "smtp.office365.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };

            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = sub
            ,
                Body = body

            })
            {
                smtp.Send(mess);
            }

            return RedirectToAction(nameof(Gracias));
        }

        [HttpGet]
        public ActionResult CodigoQR()
        {
            var cod = new CodigoQR();
            cod.Texto = "";
            cod.Codigo ="";

            return View(cod);
        }

        [HttpPost]
        public ActionResult CodigoQR(CodigoQR pcodigoQR)
        {
            var encoder = new QRCodeEncoder();
            Bitmap img = encoder.Encode(pcodigoQR.Texto);
            var QR = (Image)img;

            var cod = new CodigoQR();
            cod.Texto = "";


            using (var ms= new MemoryStream()) {
                QR.Save(ms, ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray(); 
                
                cod.Codigo="data:image/git;base64,"+Convert.ToBase64String(imageBytes);
            }



                

            return View(cod);
        }


        public ActionResult Gracias() {

            return View();
        }

        public ActionResult Confirmacion()
        {

            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




    }
}