using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using FrontEndLibros.Models.ViewModel;
using Newtonsoft.Json;

namespace FrontEndLibros.Controllers
{
    public class LibrosController : Controller
    {

        // GET: Libros
        public ActionResult Index()
        {
            List<LibroViewModel> Lista = ListarLibros();
            return View(Lista);
        }


        private static List<LibroViewModel> ListarLibros(int Id = 0)
        {
            var urlListar = $"https://localhost:44348/api/libros/ListarLibro?IdLibro={Id}";
            ResponseViewModel responseViewModel = new ResponseViewModel();
            List<LibroViewModel> libroViewModel = new List<LibroViewModel>();
            var request = (HttpWebRequest)WebRequest.Create(urlListar);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate
                (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return libroViewModel;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            responseViewModel = JsonConvert.DeserializeObject<ResponseViewModel>(responseBody);
                            libroViewModel = responseViewModel.response;
                            return libroViewModel;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return libroViewModel;
            }
        }


        public ActionResult Nuevo()
        {
            ViewBag.ListaGeneros = ListarGeneros();
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(CrearLibroViewModel Modelo)
        {

            if (ModelState.IsValid)
            {
                ResponseViewModel responseViewModel = new ResponseViewModel();
                List<LibroViewModel> libroViewModel = new List<LibroViewModel>();

                var url = $"https://localhost:44348/api/libros/InsertarLibro";
                var request = (HttpWebRequest)WebRequest.Create(url);
                string json = JsonConvert.SerializeObject(Modelo);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null)  return View(Modelo);
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                responseViewModel = JsonConvert.DeserializeObject<ResponseViewModel>(responseBody);
                                return View("/");
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    return View(Modelo);
                }
            }
            else
            {
                return View(Modelo);
            }
        }

        public List<GenerosViewModel> ListarGeneros()
        {
            List<GenerosViewModel> Lista = new List<GenerosViewModel>();
            Lista.Add(new GenerosViewModel { Id = 1, Nombre = "Prueba1" });
            Lista.Add(new GenerosViewModel { Id = 2, Nombre = "Prueba2" });
            Lista.Add(new GenerosViewModel { Id = 4, Nombre = "Prueba3" });
            return Lista;
        }

    }
}