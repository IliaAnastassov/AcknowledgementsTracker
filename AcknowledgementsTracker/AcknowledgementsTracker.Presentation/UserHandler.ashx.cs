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

            List<string> result = new List<string>();
            var users = searcher.FindUsers(prefix);

            foreach (var user in users)
            {
                // TODO: Review storing and display
                result.Add($"{user.Name} - {user.Team} : {user.Username}");
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