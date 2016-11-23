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

    /// <summary>
    /// Handles auto-complete functionality
    /// </summary>
    public class UserHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var searcher = new SearchService();
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