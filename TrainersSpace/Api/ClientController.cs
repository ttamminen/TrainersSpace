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
            return Session.Load<Client>();
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
        public void Put(int id, string value)
        {

        }

        // DELETE api/client/5
        public void Delete(int id)
        {
        }
    }
}
