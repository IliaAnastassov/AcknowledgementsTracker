using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace AcknowledgementsTracker.Presentation
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            var cookie = Context.Request.Cookies[cookieName];

            if (cookie == null)
            {
                return;
            }

            FormsAuthenticationTicket authenticationTicket;

            try
            {
                authenticationTicket = FormsAuthentication.Decrypt(cookie.Value);
            }
            catch (ArgumentException)
            {
                return;
            }

            if (authenticationTicket == null)
            {
                return;
            }

            var groups = authenticationTicket.UserData.Split(new char[] { '|' });
            var id = new GenericIdentity(authenticationTicket.Name, "LdapAuthentication");
            var principal = new GenericPrincipal(id, groups);
            Context.User = principal;
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("DashboardRoute", "AcknowledgementsTracker", @"~/Dashboard.aspx");
        }
    }
}