namespace AcknowledgementsTracker.Presentation
{
    using System;
    using System.Collections.Generic;
    using Business.Interfaces;
    using Business.Logic;
    using DTO;

    public class UIHelperService
    {
        private IUIHelper helper;

        public UIHelperService(ILdapServerConnection connection)
        {
            helper = new UIHelper(connection);
        }

        public string ReadUserFullName(string username)
        {
            return helper.GetUserFullName(username);
        }

        public IEnumerable<string> ReadTags(IEnumerable<TagDTO> tags)
        {
            return helper.GetTags(tags);
        }
    }
}
