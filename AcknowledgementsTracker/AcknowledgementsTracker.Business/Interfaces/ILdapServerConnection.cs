﻿namespace AcknowledgementsTracker.Business.Interfaces
{
    using System.DirectoryServices;

    public interface ILdapServerConnection
    {
        string Username { get; }

        DirectoryEntry SearchRoot { get; }

        DirectoryEntry RootEntry { get; }

        bool IsAuthenticated { get; }

        bool IsUIDPropertyUsed { get; }

        void Connect(ILdapSettingsService settings);
    }
}
