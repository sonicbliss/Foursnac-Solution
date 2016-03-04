﻿using Foursnac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foursnac.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Random numeroImagem = new Random();

            ViewBag.Imagem = numeroImagem.Next(7).ToString() + ".jpg";
        
            return View();
        }

        public ActionResult IndexEstabelecimento(string pagina)
        {
            try
            {
                wsSonicBliss.wsSBSoapClient ws = new wsSonicBliss.wsSBSoapClient();

                if (ws.ConfirmaUrlEstabelecimento(Authenticator.WEB_KEY, pagina))
                {
                    return Redirect("http://localhost:8080/foursnac/pedidos/main.html#PedidosMain#Delivery#" + pagina);
                }
            }
            catch (Exception)
            {

            }
            
            return View("Index");
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