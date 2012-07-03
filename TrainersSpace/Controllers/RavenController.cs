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

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Session = DocumentStoreHolder.DocumentStore.OpenSession();
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
