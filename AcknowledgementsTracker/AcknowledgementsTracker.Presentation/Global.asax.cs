﻿using System;
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
        // Urls
        public const string LoginPage = @"~/Login.aspx";
        public const string DashboardPage = @"~/Dashboard.aspx";
        public const string SearchPage = @"~/Search.aspx";
        public const string NewAcknowledgementPage = @"~/NewAcknowledgement.aspx";
        public const string EmployeeIndexPage = @"~/EmployeeIndex.aspx";

        // Label Messages
        public const string SearchEmptyQuery = "Please fill the search textbox";

        // Query strings
        public const string ModeAllTime = "allTime";
        public const string ModeAllTimeRec = "allTime_Rec";
        public const string ModeThisMonth = "thisMonth";
        public const string Beneficiary = "beneficiary";

        // Other
        public const string LdapConnection = "connection";
    }
}