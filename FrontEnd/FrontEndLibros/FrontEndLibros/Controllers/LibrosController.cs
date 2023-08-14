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
            ResponseViewModel responseViewModel = new ResponseViewModel();
            List<LibroViewModel> libroViewModel = new List<LibroViewModel>();
            var url = $"https://localhost:44348/api/libros/ListarLibro?IdLibro={Id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate
                (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
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
                // Handle error
            }
        }

        //private static void ListarLibros(int Id = 0)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();

        //    var url = $"http://localhost:8080/items";
        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    string json = $"{{\"data\":\"{data}\"}}";
        //    request.Method = "POST";
        //    request.ContentType = "application/json";
        //    request.Accept = "application/json";

        //    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        //    {
        //        streamWriter.Write(json);
        //        streamWriter.Flush();
        //        streamWriter.Close();
        //    }

        //    try
        //    {
        //        using (WebResponse response = request.GetResponse())
        //        {
        //            using (Stream strReader = response.GetResponseStream())
        //            {
        //                if (strReader == null) return;
        //                using (StreamReader objReader = new StreamReader(strReader))
        //                {
        //                    string responseBody = objReader.ReadToEnd();
        //                    // Do something with responseBody
        //                    Console.WriteLine(responseBody);
        //                }
        //            }
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        // Handle error
        //    }
        //}
    }
}