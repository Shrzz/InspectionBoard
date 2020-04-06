using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Domain
{
    public class LoginEventArgs : EventArgs
    {
        public string User { get; }
        public bool IsAuthorized { get; }
        public string Message { get; }

        public LoginEventArgs(string user, bool isAuthorized, string message)
        {
            User = user;
            IsAuthorized = isAuthorized;
            Message = message;
        }
    }
}
