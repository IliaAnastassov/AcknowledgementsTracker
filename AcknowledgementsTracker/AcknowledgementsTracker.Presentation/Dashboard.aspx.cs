﻿namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Business.Logic;

    public partial class Dashboard : System.Web.UI.Page
    {
        ////private LdapAccountManager manager = new LdapAccountManager(ConfigurationManager.AppSettings.);

        protected void Page_Load(object sender, EventArgs e)
        {
            var username = HttpContext.Current?.User?.Identity.Name;
        }
    }
}