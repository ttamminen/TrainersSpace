using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainersSpace.Models;

namespace TrainersSpace.Api
{
    public class ClientController : RavenApiController
    {
        // GET api/client
        public IEnumerable<Client> Get()
        {
            var results = Session.Query<Client>().ToList();
            return results;
        }

        // GET api/client/name
        public Client Get(string id)
        {
            return Session.Load<Client>("clients/" + id);
        }

        // POST api/client
        public void Post(Client client)
        {
            Session.Store(client);
        }

        // PUT api/client/5
        public void Put(string id, string name)
        {
            var client = Session.Load<Client>("clients/" + id);
            client.Name = name;
        }

        // DELETE api/client/5
        public void Delete(string id)
        {
            var client = Session.Load<Client>("clients/" + id);
            Session.Delete(client);
        }
    }
}
