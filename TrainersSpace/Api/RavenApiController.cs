using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Raven.Client;

namespace TrainersSpace.Api
{
    public class RavenApiController : ApiController
    {
        public IDocumentSession Session { get; set; }

        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            Session = DocumentStoreHolder.DocumentStore.OpenSession();
            return base.ExecuteAsync(controllerContext, cancellationToken)
                .ContinueWith(task =>
                {
                    using (Session)
                    {
                        if (task.Status != TaskStatus.Faulted && Session != null)
                            Session.SaveChanges();
                    }
                    return task;
                })
                .Unwrap();
        }
    }
}
