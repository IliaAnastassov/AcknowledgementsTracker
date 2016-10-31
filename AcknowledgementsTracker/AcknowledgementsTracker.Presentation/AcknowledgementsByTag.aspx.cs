namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using DTO;
    using Business.Interfaces;
    using Business.Logic;

    public partial class AcknowledgementsByTag : System.Web.UI.Page
    {
        private ILdapAccountService ldapAccountService = new LdapAccountService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetUserFullName(string username)
        {
            return ldapAccountService.ReadUserFullName(username);
        }

        protected IEnumerable<string> GetTags(IEnumerable<TagDTO> tags)
        {
            var tagTitles = new List<string>();

            foreach (var tag in tags)
            {
                tagTitles.Add(tag.Title);
            }

            return tagTitles;
        }
    }
}