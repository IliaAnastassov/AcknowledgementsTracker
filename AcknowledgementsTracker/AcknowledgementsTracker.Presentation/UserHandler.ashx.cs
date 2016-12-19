namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Business.Entities;
    using Business.Interfaces;
    using Business.Logic;
    using Newtonsoft.Json;
    using System.Web.SessionState;

    /// <summary>
    /// Handles auto-complete functionality
    /// </summary>
    public class UserHandler : IHttpHandler, IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            var connection = (ILdapServerConnection)context.Session["connection"];
            var searcher = new SearchService(connection);
            var prefix = context.Request["term"] ?? "";

            if (prefix.Trim().Length < 3)
            {
                return;
            }

            List<IUser> result = new List<IUser>();
            var users = searcher.FindUsers(prefix);

            foreach (var user in users)
            {
                result.Add(user);
            }

            context.Response.Write(JsonConvert.SerializeObject(result));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}