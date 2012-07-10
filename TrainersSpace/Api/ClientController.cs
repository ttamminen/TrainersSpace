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
        public HttpResponseMessage Post(Client client)
        {
            Session.Store(client);

            var response = Request.CreateResponse<Client>(HttpStatusCode.Created, client);

            string uri = Url.Link("DefaultApi", new { id = client.Name });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT api/client/5
        public void Put(string id, string name)
        {
            var client = Session.Load<Client>("clients/" + id);
            client.Name = name;
        }

        // DELETE api/client/5
        public HttpResponseMessage Delete(string id)
        {
            var client = Session.Load<Client>("clients/" + id);
            if (client == null)
            {
                var response = Request.CreateResponse<string>(HttpStatusCode.NotFound, id);
                return response;
            }
            Session.Delete(client);
            return Request.CreateResponse<Client>(HttpStatusCode.OK, client);
        }
    }
}
