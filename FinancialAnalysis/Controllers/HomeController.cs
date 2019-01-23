using FinancialAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Writing;

namespace FinancialAnalysis.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRdfMapper RdfMapper;

        public HomeController(IRdfMapper rdfMapper)
        {
            RdfMapper = rdfMapper;
        }

        public ActionResult Index()
        {
            RdfMapper.Init(Server.MapPath("~/App_Data/Example.rdf"));

            var clients = RdfMapper.getClients();
            
            return View(clients);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult AddClient()
        {
            ViewBag.Message = "Add client";
            var client = new Client();
            //poslati klijenta u view

            return View(client);
        }

        [HttpPost]
        public ActionResult AddClient(Client client)
        {
            RdfMapper.Init(Server.MapPath("~/App_Data/Example.rdf"));
            RdfMapper.saveClient(client);
            
            return Redirect("/");
        }
        
        public ActionResult Delete(int id)
        {

            RdfMapper.Init(Server.MapPath("~/App_Data/Example.rdf"));
            RdfMapper.deleteClient(id);

            return Redirect("/");
        }

        public ActionResult ClientDetails(int id)
        {

            RdfMapper.Init(Server.MapPath("~/App_Data/Example.rdf"));
            var client = RdfMapper.getClientById(id);

            return View(client);
        }
    }
}