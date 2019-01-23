using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Writing;

namespace FinancialAnalysis.Models
{
    public interface IRdfMapper
    {
        void Init(string filePath);
        List<Client> getClients();
        Client getClientById(int id);
        void saveClient(Client client);
        void deleteClient(int id);
    }

    public class RdfMapper: IRdfMapper
    {
        public IGraph Graph { get; set; }
        public Uri BaseUri { get; set; }
        public RdfXmlWriter RdfXmlWriter { get; set; }
        public RdfXmlParser RdfXmlParser { get; set; }
        public string FilePath { get; set; }


        public RdfMapper() {}

        public void Init(string filePath)
        {
            FilePath = filePath;

            BaseUri = UriFactory.Create("http://localhost");
            // za pisanje u datoteku
            RdfXmlWriter = new RdfXmlWriter();
            // za citanje iz datoteke
            RdfXmlParser = new RdfXmlParser();
            // graf koji ce se loadati iz datoteke
            Graph = new Graph();
            // loadanje datoteke u graf
            RdfXmlParser.Load(Graph, FilePath);

            Graph.BaseUri = BaseUri;
            Graph.NamespaceMap.AddNamespace("fa", BaseUri);
        }

        public List<Client> getClients()
        {
            var clients = new List<Client>();
            var distinctClientsUriNodes = Graph.Triples.SubjectNodes.ToList();
            foreach(INode clientUriNode1 in distinctClientsUriNodes)
            {
                var clientUriNode = clientUriNode1 as UriNode;
                var client = new Client();
                var triples = Graph.Triples.WithSubject(clientUriNode);
                foreach(Triple triple in triples)
                {
                    //triple.Predicate
                    var triplePredicate = triple.Predicate as IUriNode;
                    var str = triplePredicate.Uri.AbsolutePath.TrimStart('/');
                    var tripleObject = triple.Object as ILiteralNode;
                    var objStr = tripleObject.Value;

                    var propType = client.GetType().GetProperty(str).PropertyType;
                    if (propType == typeof(decimal))
                    {
                        client.GetType().GetProperty(str).SetValue(client, Decimal.Parse(objStr), null);
                    }
                    else if (propType == typeof(Int32))
                    {
                        client.GetType().GetProperty(str).SetValue(client, Int32.Parse(objStr), null);
                    }
                    else if (propType == typeof(DateTime))
                    {
                        client.GetType().GetProperty(str).SetValue(client, DateTime.Now, null);
                    }
                    else
                    {
                        client.GetType().GetProperty(str).SetValue(client, objStr, null);
                    }
                }
                clients.Add(client);
            }
            return clients;
        }

        private int getMaxId()
        {
            return this.getClients().Max(x => x.Id);
        }

        public Client getClientById(int id)
        {
            var distinctClientsUriNodes = Graph.Triples.SubjectNodes.ToList();
            var client = new Client();
            foreach (INode clientUriNode1 in distinctClientsUriNodes)
            {
                var clientUriNode = clientUriNode1 as UriNode;
                client = new Client();
                var triples = Graph.Triples.WithSubject(clientUriNode);
                foreach (Triple triple in triples)
                {
                    //triple.Predicate
                    var triplePredicate = triple.Predicate as IUriNode;
                    var str = triplePredicate.Uri.AbsolutePath.TrimStart('/');
                    var tripleObject = triple.Object as ILiteralNode;
                    var objStr = tripleObject.Value;

                    var propType = client.GetType().GetProperty(str).PropertyType;
                    if (propType == typeof(decimal))
                    {
                        client.GetType().GetProperty(str).SetValue(client, Decimal.Parse(objStr), null);
                    }
                    else if (propType == typeof(Int32))
                    {
                        client.GetType().GetProperty(str).SetValue(client, Int32.Parse(objStr), null);
                    }
                    else if (propType == typeof(DateTime))
                    {
                        client.GetType().GetProperty(str).SetValue(client, DateTime.Now, null);
                    }
                    else
                    {
                        client.GetType().GetProperty(str).SetValue(client, objStr, null);
                    }
                }
                if(client.Id == id)
                {
                    break;
                }
            }
            
            return client;
        }

        public void saveClient(Client client)
        {
            int newId;
            if(client.Id > 0)
            {
                newId = client.Id;
                var clientUriNode = Graph.Triples.SubjectNodes.Cast<UriNode>().FirstOrDefault(x => x.Uri.AbsolutePath.TrimStart('/').Split('/')[1] == client.Id.ToString());
                if(clientUriNode != null)
                {
                    var triples = Graph.Triples.WithSubject(clientUriNode);
                    for (int i = 0; i < triples.Count(); i++)
                    {
                        Graph.Retract(triples.ElementAt(i));
                    }
                }
            } else
            {
                newId = getMaxId() + 1;
            }
            // kreiranje subject nodea
            IUriNode clientSubject = Graph.CreateUriNode(UriFactory.Create("http://www.dotnetrdf.org/client/" + newId));
            
            // kreiranje predicate nodeova
            IUriNode clientIdPredicate = Graph.CreateUriNode("fa:Id");
            IUriNode clientNamePredicate = Graph.CreateUriNode("fa:Name");
            IUriNode clientSurnamePredicate = Graph.CreateUriNode("fa:Surname");
            IUriNode clientOIBPredicate = Graph.CreateUriNode("fa:OIB");
            IUriNode clientAgePredicate = Graph.CreateUriNode("fa:Age");
            IUriNode clientDateOfBirthPredicate = Graph.CreateUriNode("fa:DateOfBirth");
            IUriNode clientAddressPredicate = Graph.CreateUriNode("fa:Address");
            IUriNode clientZIPCodePredicate = Graph.CreateUriNode("fa:ZIPCode");
            IUriNode clientPhoneNumberPredicate = Graph.CreateUriNode("fa:PhoneNumber");
            IUriNode clientJobPredicate = Graph.CreateUriNode("fa:Job");
            IUriNode clientSalaryPredicate = Graph.CreateUriNode("fa:Salary");
            IUriNode clientCitizenshipPredicate = Graph.CreateUriNode("fa:Citizenship");
            IUriNode clientExtraIncomePredicate = Graph.CreateUriNode("fa:ExtraIncome");
            IUriNode clientRentPredicate = Graph.CreateUriNode("fa:Rent");
            IUriNode clientBillsPredicate = Graph.CreateUriNode("fa:Bills");
            IUriNode clientFoodPredicate = Graph.CreateUriNode("fa:Food");
            IUriNode clientLuxuryPredicate = Graph.CreateUriNode("fa:Luxury");
            IUriNode clientSavingsPredicate = Graph.CreateUriNode("fa:Savings");
            IUriNode clientBankPredicate = Graph.CreateUriNode("fa:Bank");
            IUriNode clientDebtAmountPredicate = Graph.CreateUriNode("fa:DebtAmount");
            IUriNode clientKidsAmountPredicate = Graph.CreateUriNode("fa:KidsAmount");
            IUriNode clientLifeInsurancePredicate = Graph.CreateUriNode("fa:LifeInsurance");
            IUriNode clientRealEstateInsurancePredicate = Graph.CreateUriNode("fa:RealEstateInsurance");
            IUriNode clientHealthInsurancePredicate = Graph.CreateUriNode("fa:HealthInsurance");
            IUriNode clientVehicleInsurancePredicate = Graph.CreateUriNode("fa:VehicleInsurance");
            IUriNode clientLifeInsuranceTypePredicate = Graph.CreateUriNode("fa:LifeInsuranceType");
            IUriNode clientRealEstateInsuranceTypePredicate = Graph.CreateUriNode("fa:RealEstateInsuranceType");
            IUriNode clientHealthInsuranceTypePredicate = Graph.CreateUriNode("fa:HealthInsuranceType");
            IUriNode clientVehicleInsuranceTypePredicate = Graph.CreateUriNode("fa:VehicleInsuranceType");

            // dodavanje tripleta u graf, za objekt citamo podatke iz clienta 
            Graph.Assert(new Triple(clientSubject, clientIdPredicate, Graph.CreateLiteralNode(newId.ToString())));
            Graph.Assert(new Triple(clientSubject, clientNamePredicate, Graph.CreateLiteralNode(client.Name)));
            Graph.Assert(new Triple(clientSubject, clientSurnamePredicate, Graph.CreateLiteralNode(client.Surname)));
            Graph.Assert(new Triple(clientSubject, clientOIBPredicate, Graph.CreateLiteralNode(client.OIB)));
            Graph.Assert(new Triple(clientSubject, clientAgePredicate, Graph.CreateLiteralNode(client.Age.ToString())));
            Graph.Assert(new Triple(clientSubject, clientDateOfBirthPredicate, Graph.CreateLiteralNode(client.DateOfBirth.ToUniversalTime().ToString())));
            Graph.Assert(new Triple(clientSubject, clientAddressPredicate, Graph.CreateLiteralNode(client.Address)));
            Graph.Assert(new Triple(clientSubject, clientZIPCodePredicate, Graph.CreateLiteralNode(client.ZIPCode.ToString())));
            Graph.Assert(new Triple(clientSubject, clientPhoneNumberPredicate, Graph.CreateLiteralNode(client.PhoneNumber)));
            Graph.Assert(new Triple(clientSubject, clientJobPredicate, Graph.CreateLiteralNode(client.Job)));
            Graph.Assert(new Triple(clientSubject, clientSalaryPredicate, Graph.CreateLiteralNode(client.Salary.ToString())));
            Graph.Assert(new Triple(clientSubject, clientCitizenshipPredicate, Graph.CreateLiteralNode(client.Citizenship)));
            Graph.Assert(new Triple(clientSubject, clientExtraIncomePredicate, Graph.CreateLiteralNode(client.ExtraIncome.ToString())));
            Graph.Assert(new Triple(clientSubject, clientRentPredicate, Graph.CreateLiteralNode(client.Rent.ToString())));
            Graph.Assert(new Triple(clientSubject, clientBillsPredicate, Graph.CreateLiteralNode(client.Bills.ToString())));
            Graph.Assert(new Triple(clientSubject, clientFoodPredicate, Graph.CreateLiteralNode(client.Food.ToString())));
            Graph.Assert(new Triple(clientSubject, clientLuxuryPredicate, Graph.CreateLiteralNode(client.Luxury.ToString())));
            Graph.Assert(new Triple(clientSubject, clientSavingsPredicate, Graph.CreateLiteralNode(client.Savings.ToString())));
            Graph.Assert(new Triple(clientSubject, clientBankPredicate, Graph.CreateLiteralNode(client.Bank)));
            Graph.Assert(new Triple(clientSubject, clientDebtAmountPredicate, Graph.CreateLiteralNode(client.DebtAmount.ToString())));
            Graph.Assert(new Triple(clientSubject, clientKidsAmountPredicate, Graph.CreateLiteralNode(client.KidsAmount.ToString())));
            Graph.Assert(new Triple(clientSubject, clientLifeInsurancePredicate, Graph.CreateLiteralNode(client.LifeInsurance.ToString())));
            Graph.Assert(new Triple(clientSubject, clientRealEstateInsurancePredicate, Graph.CreateLiteralNode(client.RealEstateInsurance.ToString())));
            Graph.Assert(new Triple(clientSubject, clientHealthInsurancePredicate, Graph.CreateLiteralNode(client.HealthInsurance.ToString())));
            Graph.Assert(new Triple(clientSubject, clientVehicleInsurancePredicate, Graph.CreateLiteralNode(client.VehicleInsurance.ToString())));
            Graph.Assert(new Triple(clientSubject, clientLifeInsuranceTypePredicate, Graph.CreateLiteralNode(client.LifeInsuranceType ?? "")));
            Graph.Assert(new Triple(clientSubject, clientRealEstateInsuranceTypePredicate, Graph.CreateLiteralNode(client.RealEstateInsuranceType ?? "")));
            Graph.Assert(new Triple(clientSubject, clientHealthInsuranceTypePredicate, Graph.CreateLiteralNode(client.HealthInsuranceType ?? "")));
            Graph.Assert(new Triple(clientSubject, clientVehicleInsuranceTypePredicate, Graph.CreateLiteralNode(client.VehicleInsuranceType ?? "")));

            saveGraphToFile();
        }

        public void deleteClient(int id)
        {
            var clientUriNode = Graph.Triples.SubjectNodes.Cast<UriNode>().FirstOrDefault(x => x.Uri.AbsolutePath.TrimStart('/').Split('/')[1] == id.ToString());

            if (clientUriNode != null)
            {
                var triples = Graph.Triples.WithSubject(clientUriNode);
                for(int i = 0; i < triples.Count(); i++)
                {
                    Graph.Retract(triples.ElementAt(i));
                }
            }
            saveGraphToFile();
        }

        private void saveGraphToFile()
        {
            RdfXmlWriter.Save(Graph, FilePath);
        }
    }
}