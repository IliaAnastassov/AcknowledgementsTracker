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
        public const string LoginPage = @"~/Login.aspx";
        public const string DashboardPage = @"~/Dashboard.aspx";
        public const string SearchPage = @"~/Search.aspx";
        public const string NewAcknowledgementPage = @"~/NewAcknowledgement.aspx";
        public const string EmployeeIndexPage = @"~/EmployeeIndex.aspx";

        public bool UserLoggedIn { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {
        }
    }
}