using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client.Document;
using Raven.Client.Linq;
using Raven.Client;

namespace TrainersSpace.Controllers
{
    public class RavenController : Controller
    {
        public new IDocumentSession Session { get; set; }

        public static IDocumentStore documentStore;
        public static IDocumentStore DocumentStore
        {
            get
            {
                if (documentStore != null)
                    return documentStore;

                lock (typeof(RavenController))
                {
                    if (documentStore != null)
                        return documentStore;

                    documentStore = new DocumentStore
                    {
                        ConnectionStringName = "RavenDB"
                    }.Initialize();
                }

                return documentStore;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Session = DocumentStore.OpenSession();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.IsChildAction)
                return;

            using (Session)
            {
                if (filterContext.Exception != null)
                    return;

                if (Session != null)
                    Session.SaveChanges();
            }
        }
    }
}
