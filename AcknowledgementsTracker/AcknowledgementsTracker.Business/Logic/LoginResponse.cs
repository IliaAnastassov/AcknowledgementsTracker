namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using Interfaces;

    public class LoginResponse : ILoginResponse
    {
        public string ResponseMessage { get; set; }

        public IUser User { get; set; }
    }
}
